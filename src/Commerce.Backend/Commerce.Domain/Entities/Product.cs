using Commerce.Domain.Common.Entities;
using static System.Collections.Specialized.BitVector32;

namespace Commerce.Domain.Entities;

public class Product : AuditableEntity
{
    public string Model { get; set; }
    public string IdentificationNumber { get; set; } // Unique
    public int Priority { get; set; }
    public string Link { get; set; }
    public string MetaTitle { get; set; }
    public string MetaTags { get; set; }
    public string MetaDescription { get; set; }
    public float Price { get; set; }
    public int Extra { get; set; } // 1 - 100
    public float Profit { get; set; }
    public string Warehouse { get; set; }
    public int Amount { get; set; }
    public bool Availability { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Views { get; set; }

    public Guid ProductManufacturerId { get; set; }
    public ProductManufacturer ProductManufacturer { get; set; }

    public Guid SectionId { get; set; }
    public Section Section { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<Sale> Sales { get; set; }
}
