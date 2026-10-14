namespace Lab08_ChambiLuque.Core.Application.Dtos;

public class ClientOrderDto
{
    public string ClientName { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
}