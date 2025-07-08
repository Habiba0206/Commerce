using Commerce.Domain.Common.Entities;

namespace Commerce.Domain.Entities;

public class ProductManufacturer : AuditableEntity
{
    public string Name { get; set; } // Unique

    public ICollection<Product> Products { get; set; }
}
