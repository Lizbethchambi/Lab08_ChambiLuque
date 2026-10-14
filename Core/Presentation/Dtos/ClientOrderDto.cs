namespace Lab08_ChambiLuque.Core.Presentation.Dtos;

public class ClientOrderDto
{
    public string ClientName { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
}