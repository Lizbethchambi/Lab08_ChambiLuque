using Microsoft.AspNetCore.Mvc;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;

namespace Lab08_ChambiLuque.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productoService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product producto)
    {
        _productoService.Crear(producto);
        return Ok(new { message = "Producto creado" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product producto)
    {
        if (_productoService.ObtenerPorId(id) == null)
            return NotFound(new { message = "Producto no encontrado" });

        producto.ProductId = id;
        _productoService.Actualizar(producto);
        return Ok(new { message = "Producto actualizado" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productoService.Eliminar(id);
        return Ok(new { message = "Producto eliminado" });
    }

    [HttpGet("price-greater-than")]
    public async Task<IActionResult> GetProductsPriceGreaterThan([FromQuery] decimal price)
    {
        var result = await _productoService.GetProductsPriceGreaterThanAsync(price);
        return Ok(result);
    }
    
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var result = await _productoService.GetMostExpensiveProductAsync();
        return Ok(result);
    }
    
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAverageProductPrice()
    {
        var result = await _productoService.GetAverageProductPriceAsync();
        return Ok(result);
    }

    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var result = await _productoService.GetProductsWithoutDescriptionAsync();
        return Ok(result);
    }

    [HttpGet("by-client/{clientId}")]
    public async Task<IActionResult> GetProductsByClientId(int clientId)
    {
        var result = await _productoService.GetProductsByClientIdAsync(clientId);
        return Ok(result);
    }
    
    [HttpGet("top-3-selling")]
    public async Task<IActionResult> GetTop3SellingProducts()
    {
        var result = await _productoService.GetTop3SellingProductsAsync();
        return Ok(result);
    }
}