using ECO.Application;
using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories.Order;
using ECO.Application.Repositories;
using ECO.Persistence;
using ECO.Persistence.Context;
using ECO.Persistence.Repositories;
using ECO.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ECO.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddScoped<IOrderService, OrderService>();




builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECODB"));
});

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
