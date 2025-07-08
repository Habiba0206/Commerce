using Commerce.Application.Categories.Models;
using Commerce.Application.Countries.Models;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sections.Models;

namespace Commerce.Application.Products.Models;

public class ProductGetDto
{
    public Guid Id { get; set; }
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
    public ProductManufacturerCreateUpdateDto ProductManufacturer { get; set; }

    public Guid SectionId { get; set; }
    public SectionCreateUpdateDto Section { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryCreateUpdateDto Category { get; set; }

    public Guid CountryId { get; set; }
    public CountryCreateUpdateDto Country { get; set; }

    public ICollection<SaleCreateUpdateDto> Sales { get; set; }
    public bool IsDeleted { get; set; }
}
