using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Application.Dtos;

namespace Lab08_ChambiLuque.Core.Application.Interfaces;

public interface IClienteRepository
{
    //Metodos del lab08
    IEnumerable<Client> GetAll();
    Client? GetById(int id);
    void Add(Client cliente);
    void Update(Client cliente);
    void Delete(int id);
    
    Task<List<Client>> GetByNameAsync(string name);
    Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync();
    Task<List<string>> GetClientsByProductIdAsync(int productId);
    
    //Metodos del lab09
    
    //Paso 2: Consulta con AsNoTracking()
    Task<List<ClientOrderDto>> GetClientOrdersOptimizedAsync();
        
    //Paso 4: Obtener clientes con el total de productos comprados
    Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync();
}