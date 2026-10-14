using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.UseCases;

public class OrdenUseCase : IOrdenService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Order> ObtenerTodos()
    {
        return _unitOfWork.Ordenes.GetAll();
    }

    public Order? ObtenerPorId(int id)
    {
        return _unitOfWork.Ordenes.GetById(id);
    }

    public void Crear(Order orden)
    {
        _unitOfWork.Ordenes.Add(orden);
        _unitOfWork.SaveChanges();
    }

    public void Actualizar(Order orden)
    {
        _unitOfWork.Ordenes.Update(orden);
        _unitOfWork.SaveChanges();
    }

    public void Eliminar(int id)
    {
        _unitOfWork.Ordenes.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public async Task<List<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.Ordenes.GetOrderDetailsByOrderIdAsync(orderId);
    }

    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.Ordenes.GetTotalProductQuantityByOrderIdAsync(orderId);
    }

    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _unitOfWork.Ordenes.GetOrdersAfterDateAsync(date);
    }

    public async Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _unitOfWork.Ordenes.GetAllOrdersWithDetailsAsync();
    }
    
    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsOptimizedAsync()
    {
        return await _unitOfWork.Ordenes.GetOrdersWithDetailsOptimizedAsync();
    }

    public async Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        return await _unitOfWork.Ordenes.GetSalesByClientAsync();
    }
}