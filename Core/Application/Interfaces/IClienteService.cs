using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Presentation.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IClienteService
{
    //Metodos del lab 08
    IEnumerable<Client> ObtenerTodos();
    Client? ObtenerPorId(int id);
    void Crear(Client cliente);
    void Actualizar(Client cliente);
    void Eliminar(int id);

    Task<List<Client>> GetClientsByNameAsync(string name);
    Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync();
    Task<List<string>> GetClientsByProductIdAsync(int productId);
    
    //Metodos del lab 09
    
    Task<List<ClientOrderDto>> GetClientOrdersOptimizedAsync();
    Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync();
}