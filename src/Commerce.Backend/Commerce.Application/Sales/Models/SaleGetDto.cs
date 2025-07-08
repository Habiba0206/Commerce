using Commerce.Application.Products.Models;

namespace Commerce.Application.Sales.Models;

public class SaleGetDto
{
    public Guid Id { get; set; }
    public int QuantitySold { get; set; }
    public float SalePrice { get; set; }
    public DateTime SaleDate { get; set; }

    public Guid ProductId { get; set; }
    public ProductCreateUpdateDto Product { get; set; }
    public bool IsDeleted { get; set; }
}
