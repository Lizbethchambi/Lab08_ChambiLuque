using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Presentation.Dtos;

namespace Lab08_ChambiLuque.Core.Application.UseCases;

public class DetalleOrdenUseCase : IDetalleOrdenService
{
    private readonly IUnitOfWork _unitOfWork;

    public DetalleOrdenUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Orderdetail> ObtenerTodos()
    {
        return _unitOfWork.DetallesOrden.GetAll();
    }

    public Orderdetail? ObtenerPorId(int id)
    {
        return _unitOfWork.DetallesOrden.GetById(id);
    }

    public void Crear(Orderdetail detalle)
    {
        _unitOfWork.DetallesOrden.Add(detalle);
        _unitOfWork.SaveChanges();
    }

    public void Actualizar(Orderdetail detalle)
    {
        _unitOfWork.DetallesOrden.Update(detalle);
        _unitOfWork.SaveChanges();
    }

    public void Eliminar(int id)
    {
        _unitOfWork.DetallesOrden.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public async Task<List<OrderDetailDto>> ObtenerDetallesPorOrdenAsync(int orderId)
    {
        return await _unitOfWork.DetallesOrden.AddAsync(orderId);
    }

    public async Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId)
    {
        return await _unitOfWork.DetallesOrden.ObtenerCantidadTotalPorOrdenAsync(orderId);
    }
}