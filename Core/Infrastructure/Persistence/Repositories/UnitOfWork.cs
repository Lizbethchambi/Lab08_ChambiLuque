using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Infrastructure.Persistence.Context;

namespace Lab08_ChambiLuque.Core.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LinqexampleContext _context;

    public IClienteRepository Clientes { get; }
    public IProductoRepository Productos { get; }
    public IOrdenRepository Ordenes { get; }
    public IDetalleOrdenRepository DetallesOrden { get; }

    public UnitOfWork(LinqexampleContext context)
    {
        _context = context;
        Clientes = new ClienteRepository(_context);
        Productos = new ProductoRepository(_context);
        Ordenes = new OrderRepository(_context);
        DetallesOrden = new DetalleOrdenRepository(_context);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}