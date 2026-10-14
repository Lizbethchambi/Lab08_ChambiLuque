using Lab08_ChambiLuque.Core.Application.Interfaces;
using Lab08_ChambiLuque.Core.Domain.Entities;
using Lab08_ChambiLuque.Core.Presentation.Dtos;

namespace Lab08_ChambiLuque.Core.Application.UseCases;

public class ClienteUseCase : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Client> ObtenerTodos()
    {
        return _unitOfWork.Clientes.GetAll();
    }

    public Client? ObtenerPorId(int id)
    {
        return _unitOfWork.Clientes.GetById(id);
    }

    public void Crear(Client cliente)
    {
        _unitOfWork.Clientes.Add(cliente);
        _unitOfWork.SaveChanges();
    }

    public void Actualizar(Client cliente)
    {
        _unitOfWork.Clientes.Update(cliente);
        _unitOfWork.SaveChanges();
    }

    public void Eliminar(int id)
    {
        _unitOfWork.Clientes.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public async Task<List<Client>> GetClientsByNameAsync(string name)
    {
        return await _unitOfWork.Clientes.GetByNameAsync(name);
    }

    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return await _unitOfWork.Clientes.GetClientWithMostOrdersAsync();
    }

    public async Task<List<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _unitOfWork.Clientes.GetClientsByProductIdAsync(productId);
    }
    
    public async Task<List<ClientOrderDto>> GetClientOrdersOptimizedAsync()
    {
        return await _unitOfWork.Clientes.GetClientOrdersOptimizedAsync();
    }

    public async Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync()
    {
        return await _unitOfWork.Clientes.GetClientsWithProductCountAsync();
    }
}