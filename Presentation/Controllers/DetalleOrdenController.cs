using Microsoft.AspNetCore.Mvc;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;

namespace Lab08_ChambiLuque.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleOrdenController : ControllerBase
{
    private readonly IDetalleOrdenService _detalleOrdenService;

    public DetalleOrdenController(IDetalleOrdenService detalleOrdenService)
    {
        _detalleOrdenService = detalleOrdenService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_detalleOrdenService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var detalle = _detalleOrdenService.ObtenerPorId(id);
        if (detalle == null)
        {
            return NotFound();
        }
        return Ok(detalle);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Orderdetail detalle)
    {
        _detalleOrdenService.Crear(detalle);
        return Ok(new { message = "Detalle de orden creado" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Orderdetail detalle)
    {
        if (_detalleOrdenService.ObtenerPorId(id) == null)
            return NotFound(new { message = "Detalle no encontrado" });

        detalle.OrderDetailId = id;
        _detalleOrdenService.Actualizar(detalle);
        return Ok(new { message = "Detalle de orden actualizado" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _detalleOrdenService.Eliminar(id);
        return Ok(new { message = "Detalle de orden eliminado" });
    }

    [HttpGet("by-order/{orderId}")]
    public async Task<IActionResult> GetByOrderId(int orderId)
    {
        var result = await _detalleOrdenService.ObtenerDetallesPorOrdenAsync(orderId);
        return Ok(result);
    }

    [HttpGet("total-quantity/{orderId}")]
    public async Task<IActionResult> GetTotalQuantityByOrderId(int orderId)
    {
        var result = await _detalleOrdenService.ObtenerCantidadTotalPorOrdenAsync(orderId);
        return Ok(result);
    }
}