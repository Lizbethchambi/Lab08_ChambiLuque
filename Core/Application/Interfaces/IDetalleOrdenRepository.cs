using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Presentation.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IDetalleOrdenRepository
{
    IEnumerable<Orderdetail> GetAll();
    Orderdetail? GetById(int id);
    void Add(Orderdetail detalle);
    void Update(Orderdetail detalle);
    void Delete(int id);

    Task<List<OrderDetailDto>> AddAsync(int orderId);
    Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId);
}