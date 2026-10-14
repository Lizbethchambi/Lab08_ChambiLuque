using Lab08_ChambiLuque.Core.Application.Dtos;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Infrastructure.Persistence.Context; 
using Microsoft.EntityFrameworkCore;

namespace Lab08_ChambiLuque.Infrastructure.Persistence.Repositories;
public class ClienteRepository : IClienteRepository
{
    private readonly LinqexampleContext _context;

    public ClienteRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public IEnumerable<Client> GetAll()
    {
        return _context.Clients.ToList();
    }

    public Client? GetById(int id)
    {
        return _context.Clients.Find(id);
    }

    public void Add(Client cliente)
    {
        _context.Clients.Add(cliente);
    }

    public void Update(Client cliente)
    {
        _context.Clients.Update(cliente);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Clients.Remove(entity);
        }
    }
    
    public async Task<List<Client>> GetByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }
    
    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(g => new ClientOrderCountDto
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(g => g.OrderCount)
            .FirstOrDefaultAsync();
    }
    
    public async Task<List<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
    
    public async Task<List<ClientOrderDto>> GetClientOrdersOptimizedAsync()
    {
        return await _context.Clients
            .AsNoTracking() 
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders
                    .Select(order => new OrderDto
                    {
                        OrderId = order.OrderId,
                        OrderDate = order.OrderDate
                    }).ToList()
            })
            .ToListAsync();
    }
    
    public async Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(client => new ClientProductCountDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .Sum(order => order.Orderdetails
                        .Sum(detail => detail.Quantity))
            })
            .ToListAsync();
    }
}