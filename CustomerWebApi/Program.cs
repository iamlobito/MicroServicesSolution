using CustomerWebApi;
using CustomerWebApi.Repository;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<CustomerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.Decorate<ICustomerRepository, CachedCustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddHealthChecks();

builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("DBConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseAuthorization();

app.MapControllers();

app.Run();
