using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiVeiculos.Data;
using WebApiVeiculos.Repositores;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApiVeiculosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiVeiculosContext") ?? throw new InvalidOperationException("Connection string 'WebApiVeiculosContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVeiculosRepository, VeiculosRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
