using Microsoft.AspNetCore.Mvc;
using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;

namespace Lab08_ChambiLuque.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_clienteService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _clienteService.ObtenerPorId(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Client cliente)
    {
        _clienteService.Crear(cliente);
        return Ok(new { message = "Cliente creado" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Client cliente)
    {
        if (_clienteService.ObtenerPorId(id) == null)
            return NotFound(new { message = "Cliente no encontrado" });

        cliente.ClientId = id;   
        _clienteService.Actualizar(cliente);
        return Ok(new { message = "Cliente actualizado" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _clienteService.Eliminar(id);
        return Ok(new { message = "Cliente eliminado" });
    }

    [HttpGet("by-name")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        var result = await _clienteService.GetClientsByNameAsync(name);
        return Ok(result);
    }

    [HttpGet("most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var result = await _clienteService.GetClientWithMostOrdersAsync();
        return Ok(result);
    }

    [HttpGet("by-product/{productId}")]
    public async Task<IActionResult> GetClientsByProductId(int productId)
    {
        var result = await _clienteService.GetClientsByProductIdAsync(productId);
        return Ok(result);
    }
    
    [HttpGet("orders-optimized")]
    public async Task<IActionResult> GetClientOrdersOptimized()
    {
        var result = await _clienteService.GetClientOrdersOptimizedAsync();
        return Ok(result);
    }

    [HttpGet("products-count")]
    public async Task<IActionResult> GetClientsWithProductCount()
    {
        var result = await _clienteService.GetClientsWithProductCountAsync();
        return Ok(result);
    }
}