using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.UseCases;

public class ProductoUseCase : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Product> ObtenerTodos()
    {
        return _unitOfWork.Productos.GetAll();
    }

    public Product? ObtenerPorId(int id)
    {
        return _unitOfWork.Productos.GetById(id);
    }

    public void Crear(Product producto)
    {
        _unitOfWork.Productos.Add(producto);
        _unitOfWork.SaveChanges();
    }

    public void Actualizar(Product producto)
    {
        _unitOfWork.Productos.Update(producto);
        _unitOfWork.SaveChanges();
    }

    public void Eliminar(int id)
    {
        _unitOfWork.Productos.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public async Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal price)
    {
        return await _unitOfWork.Productos.GetProductsPriceGreaterThanAsync(price);
    }

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _unitOfWork.Productos.GetMostExpensiveProductAsync();
    }

    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _unitOfWork.Productos.GetAverageProductPriceAsync();
    }

    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _unitOfWork.Productos.GetProductsWithoutDescriptionAsync();
    }

    public async Task<List<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _unitOfWork.Productos.GetProductsByClientIdAsync(clientId);
    }
    
    public async Task<List<ProductSummaryDto>> GetTop3SellingProductsAsync()
    {
        return await _unitOfWork.Productos.GetTop3SellingProductsAsync();
    }
}