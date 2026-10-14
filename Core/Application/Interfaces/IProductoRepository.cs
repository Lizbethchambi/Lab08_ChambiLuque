using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Presentation.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IProductoRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    void Add(Product producto);
    void Update(Product producto);
    void Delete(int id);

    Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal price);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();
    Task<List<string>> GetProductsByClientIdAsync(int clientId);
    
    //lab09 
    Task<List<ProductSummaryDto>> GetTop3SellingProductsAsync();
}