using Microsoft.EntityFrameworkCore;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Application.UseCases;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Infrastructure.Persistence.Context;     
using Lab08_ChambiLuque.Infrastructure.Persistence.Repositories;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<LinqexampleContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Inyección de dependencias apuntando a las interfaces y casos de uso
builder.Services.AddScoped<IClienteService, ClienteUseCase>();
builder.Services.AddScoped<IProductoService, ProductoUseCase>();
builder.Services.AddScoped<IOrdenService, OrdenUseCase>();
builder.Services.AddScoped<IDetalleOrdenService, DetalleOrdenUseCase>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();