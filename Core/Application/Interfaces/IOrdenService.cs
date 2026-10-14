using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IOrdenService
{
    IEnumerable<Order> ObtenerTodos();
    Order? ObtenerPorId(int id);
    void Crear(Order orden);
    void Actualizar(Order orden);
    void Eliminar(int id);

    Task<List<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync();
    
    //Lab 09
    
    Task<List<OrderDetailsDto>> GetOrdersWithDetailsOptimizedAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}