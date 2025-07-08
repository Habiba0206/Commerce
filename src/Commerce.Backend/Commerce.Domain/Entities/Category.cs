using Commerce.Domain.Common.Entities;

namespace Commerce.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; } //Unique

    public ICollection<Product> Products { get; set; }
}
