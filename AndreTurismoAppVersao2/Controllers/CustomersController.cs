using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.Data;
using AndreTurismoApp.Services;

namespace AndreTurismoAppVersao2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AndreTurismoAppVersao2Context _context;
        private readonly PostOfficesService _postOfficesService;

        public CustomersController(AndreTurismoAppVersao2Context context, PostOfficesService postOfficesService)
        {
            _context = context;
            _postOfficesService = postOfficesService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            return await _context.Customer.Include(a => a.Address.City).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.Include(a => a.Address.City).Where(client => client.Id == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer, string cep)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'AndreTurismoAppVersao2Context.Customer'  is null.");
            }

            var addressDTO = _postOfficesService.GetAddress(cep).Result;

            //customer.Address.Number = n;
            customer.Address.Neighborhood = addressDTO.Neighborhood;
            customer.Address.Complement = addressDTO.Complement;
            customer.Address.ZipCode = addressDTO.ZipCode;
            //customer.Address.Country = addressDTO.Country;
            customer.Address.State = addressDTO.State;
            customer.Address.Street = addressDTO.Street;
            customer.Address.City = new City()
            {
                Description = addressDTO.City
            };

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
