using Commerce.Domain.Common.Entities;

namespace Commerce.Domain.Entities;

public class Country : AuditableEntity
{
    public string Name { get; set; } //unique
}
