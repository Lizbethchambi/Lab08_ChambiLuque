using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Infrastructure.Persistence.Context; 
using Lab08_ChambiLuque.Core.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ChambiLuque.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrdenRepository
{
    private readonly LinqexampleContext _context;

    public OrderRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders.ToList();
    }

    public Order? GetById(int id)
    {
        return _context.Orders.Find(id);
    }

    public void Add(Order orden)
    {
        _context.Orders.Add(orden);
    }

    public void Update(Order orden)
    {
        _context.Orders.Update(orden);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Orders.Remove(entity);
        }
    }

    public async Task<List<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
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

    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }

    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .ToListAsync();
    }

    public async Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _context.Orderdetails
            .Where(od => od.Quantity > 0)
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsOptimizedAsync()
    {
        return await _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.Orderdetails
                    .Select(od => new ProductDto
                    {
                        ProductId = od.Product.ProductId,
                        Name = od.Product.Name,
                        Price = od.Product.Price
                    }).ToList()
            })
            .ToListAsync();
    }
    
    public async Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        return await _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .GroupBy(order => order.ClientId)
            .Select(group => new SalesByClientDto
            {
                ClientName = _context.Clients
                    .FirstOrDefault(c => c.ClientId == group.Key)!.Name,
                TotalSales = group.Sum(order => order.Orderdetails
                    .Sum(detail => detail.Quantity * detail.Product.Price))
            })
            .OrderByDescending(s => s.TotalSales)
            .ToListAsync();
    }
}