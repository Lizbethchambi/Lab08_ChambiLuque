namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    IProductoRepository Productos { get; }
    IOrdenRepository Ordenes { get; }
    IDetalleOrdenRepository DetallesOrden { get; }
    int SaveChanges();
}