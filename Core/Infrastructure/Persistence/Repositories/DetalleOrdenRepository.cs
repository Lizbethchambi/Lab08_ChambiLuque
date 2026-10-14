using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Infrastructure.Persistence.Context;
using Lab08_ChambiLuque.Core.Presentation.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ChambiLuque.Core.Infrastructure.Persistence.Repositories;

public class DetalleOrdenRepository : IDetalleOrdenRepository
{
    private readonly LinqexampleContext _context;

    public DetalleOrdenRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public IEnumerable<Orderdetail> GetAll()
    {
        return _context.Orderdetails.ToList();
    }

    public Orderdetail? GetById(int id)
    {
        return _context.Orderdetails.Find(id);
    }

    public void Add(Orderdetail detalle)
    {
        _context.Orderdetails.Add(detalle);
    }

    public void Update(Orderdetail detalle)
    {
        _context.Orderdetails.Update(detalle);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Orderdetails.Remove(entity);
        }
    }

    public async Task<List<OrderDetailDto>> AddAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    public async Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }
}