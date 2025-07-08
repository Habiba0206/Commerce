using Commerce.Domain.Common.Entities;

namespace Commerce.Domain.Entities;

public class Sale : AuditableEntity
{
    public int QuantitySold { get; set; }
    public float SalePrice { get; set; }
    public DateTime SaleDate { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
