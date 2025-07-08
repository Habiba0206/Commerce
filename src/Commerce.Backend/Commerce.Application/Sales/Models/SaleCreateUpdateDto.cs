namespace Commerce.Application.Sales.Models;

public class SaleCreateUpdateDto
{
    public int QuantitySold { get; set; }
    public float SalePrice { get; set; }
    public DateTime SaleDate { get; set; }

    public Guid ProductId { get; set; }
}