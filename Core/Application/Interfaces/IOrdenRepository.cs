using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IOrdenRepository
{
    //Metodo de lab 08
    IEnumerable<Order> GetAll();
    Order? GetById(int id);
    void Add(Order orden);
    void Update(Order orden);
    void Delete(int id);

    Task<List<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync();
    
    //Metodo de lab 09
    
    //Paso 3
    Task<List<OrderDetailsDto>> GetOrdersWithDetailsOptimizedAsync();
    
    //Paso 5 
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}