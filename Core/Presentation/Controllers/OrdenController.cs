using Microsoft.AspNetCore.Mvc;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;

namespace Lab08_ChambiLuque.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenController : ControllerBase
{
    private readonly IOrdenService _ordenService;

    public OrdenController(IOrdenService ordenService)
    {
        _ordenService = ordenService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_ordenService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var orden = _ordenService.ObtenerPorId(id);
        if (orden == null)
        {
            return NotFound();
        }
        return Ok(orden);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Order orden)
    {
        _ordenService.Crear(orden);
        return Ok(new { message = "Orden creada" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Order orden)
    {
        if (_ordenService.ObtenerPorId(id) == null)
            return NotFound(new { message = "Orden no encontrada" });

        orden.OrderId = id;
        _ordenService.Actualizar(orden);
        return Ok(new { message = "Orden actualizada" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ordenService.Eliminar(id);
        return Ok(new { message = "Orden eliminada" });
    }

    [HttpGet("details/{orderId}")]
    public async Task<IActionResult> GetDetails(int orderId)
    {
        var result = await _ordenService.GetOrderDetailsByOrderIdAsync(orderId);
        return Ok(result);
    }

    [HttpGet("{orderId}/total-quantity")]
    public async Task<IActionResult> GetTotalQuantity(int orderId)
    {
        var result = await _ordenService.GetTotalProductQuantityByOrderIdAsync(orderId);
        return Ok(result);
    }

    [HttpGet("after-date/{date}")]
    public async Task<IActionResult> GetAfterDate(DateTime date)
    {
        var result = await _ordenService.GetOrdersAfterDateAsync(date);
        return Ok(result);
    }

    [HttpGet("all-details")]
    public async Task<IActionResult> GetAllDetails()
    {
        var result = await _ordenService.GetAllOrdersWithDetailsAsync();
        return Ok(result);
    }
    
    [HttpGet("details-optimized")]
    public async Task<IActionResult> GetOrdersWithDetailsOptimized()
    {
        var result = await _ordenService.GetOrdersWithDetailsOptimizedAsync();
        return Ok(result);
    }

    [HttpGet("sales-by-client")]
    public async Task<IActionResult> GetSalesByClient()
    {
        var result = await _ordenService.GetSalesByClientAsync();
        return Ok(result);
    }
}