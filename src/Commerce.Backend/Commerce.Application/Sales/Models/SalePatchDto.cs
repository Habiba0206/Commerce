namespace Commerce.Application.Sales.Models;

public class SalePatchDto
{
    public Guid Id { get; set; }
    public int? QuantitySold { get; set; }
    public float? SalePrice { get; set; }
    public DateTime? SaleDate { get; set; }

    public Guid? ProductId { get; set; }
}
