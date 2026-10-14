using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Infrastructure.Persistence.Context;
using Lab08_ChambiLuque.Core.Presentation.Dtos;
using Microsoft.EntityFrameworkCore;


namespace Lab08_ChambiLuque.Core.Infrastructure.Persistence.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly LinqexampleContext _context;

    public ProductoRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void Add(Product producto)
    {
        _context.Products.Add(producto);
    }

    public void Update(Product producto)
    {
        _context.Products.Update(producto);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
        }
    }

    public async Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal price)
    {
        return await _context.Products
            .Where(p => p.Price > price)
            .ToListAsync();
    }

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _context.Products
            .Select(p => p.Price)
            .AverageAsync();
    }

    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    public async Task<List<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
    
    public async Task<List<ProductSummaryDto>> GetTop3SellingProductsAsync()
    {
        return await _context.Orderdetails
            .AsNoTracking()
            .GroupBy(od => od.ProductId)
            .OrderByDescending(g => g.Sum(od => od.Quantity)) 
            .Select(g => new ProductSummaryDto
            {
                ProductId = g.Key,
                Name = g.First().Product.Name,
                Price = g.First().Product.Price
            })
            .Take(3)
            .ToListAsync();
    }
}