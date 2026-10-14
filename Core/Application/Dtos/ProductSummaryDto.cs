namespace Lab08_ChambiLuque.Core.Application.Dtos;
public class ProductSummaryDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}