using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IDetalleOrdenService
{
    IEnumerable<Orderdetail> ObtenerTodos();
    Orderdetail? ObtenerPorId(int id);
    void Crear(Orderdetail detalle);
    void Actualizar(Orderdetail detalle);
    void Eliminar(int id);

    Task<List<OrderDetailDto>> ObtenerDetallesPorOrdenAsync(int orderId);
    Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId);
}