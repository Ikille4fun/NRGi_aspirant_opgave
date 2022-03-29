using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NRGi_aspirant_opgave.Data;
using NRGi_aspirant_opgave.Models;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<NRGi_aspirant_opgaveContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("NRGi_aspirant_opgaveContext")));

builder.Services.AddDbContext<NRGi_aspirant_opgaveContext>(options =>
options.UseInMemoryDatabase("Test"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
