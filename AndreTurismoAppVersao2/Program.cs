using AndreTurismoApp.Services;
using AndreTurismoAppVersao2.AddressService;
using AndreTurismoAppVersao2.Services1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndreTurismoAppVersao2.Data;
using AndreTurismoAppVersao2.CustomerServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AndreTurismoAppVersao2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AndreTurismoAppVersao2Context") ?? throw new InvalidOperationException("Connection string 'AndreTurismoAppVersao2Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PostOfficesService>();
builder.Services.AddSingleton<PackageService1>();
builder.Services.AddSingleton<TicketService1>();
builder.Services.AddSingleton<HotelService1>();
builder.Services.AddSingleton<HotelService1>();
builder.Services.AddSingleton<CustomerService1>();
builder.Services.AddSingleton<AddressService1>();
builder.Services.AddSingleton<CityService1>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
