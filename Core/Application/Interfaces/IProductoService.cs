using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IProductoService
{
    IEnumerable<Product> ObtenerTodos();
    Product? ObtenerPorId(int id);
    void Crear(Product producto);
    void Actualizar(Product producto);
    void Eliminar(int id);

    Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal price);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();
    Task<List<string>> GetProductsByClientIdAsync(int clientId);
    
    //lab09 
    Task<List<ProductSummaryDto>> GetTop3SellingProductsAsync();
}