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
using AndreTurismoAppVersao2.AddressService;
using AndreTurismoAppVersao2.Services1;

namespace AndreTurismoAppVersao2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService1 _ticketService1;
        private readonly PostOfficesService _postOfficesService;

        public TicketsController(TicketService1 ticketService1, PostOfficesService postOfficesService)
        {
            _ticketService1 = ticketService1;
            _postOfficesService = postOfficesService;
        }

        // Listar todos
        [HttpGet]
        public async Task<List<Ticket>> GetTicket()
        {
            return await _ticketService1.GetTicket();
        }

        // Busca por Id
        [HttpGet("{id}")]
        public async Task<Ticket> GetById(int id)
        {
            return await _ticketService1.GetById(id);
        }

        // Inserir novo
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket, string cep1, string cep2)
        {
            var addressDTO = _postOfficesService.GetAddress(cep1).Result;

            ticket.Origin.Neighborhood = addressDTO.Neighborhood;
            ticket.Origin.Complement = addressDTO.Complement;
            ticket.Origin.ZipCode = addressDTO.ZipCode;
            ticket.Origin.State = addressDTO.State;
            ticket.Origin.Street = addressDTO.Street;
            ticket.Origin.City = new City()
            {
                Description = addressDTO.City
            };

            var addressDTO2 = _postOfficesService.GetAddress(cep2).Result;

            ticket.Destination.Neighborhood = addressDTO2.Neighborhood;
            ticket.Destination.Complement = addressDTO2.Complement;
            ticket.Destination.ZipCode = addressDTO2.ZipCode;
            ticket.Destination.State = addressDTO2.State;
            ticket.Destination.Street = addressDTO2.Street;
            ticket.Destination.City = new City()
            {
                Description = addressDTO2.City
            };

            return await _ticketService1.Insert(ticket);
        }

        //Atualiza 
        [HttpPut("{id}")]
        public async Task<Ticket> Update(Ticket t)
        {
            return await _ticketService1.Update(t);
        }

        // Deleta 
        [HttpDelete("{id}")]
        public async Task<Ticket> Delete(int id)
        {
            return await _ticketService1.Delete(id);
        }

    }
}
