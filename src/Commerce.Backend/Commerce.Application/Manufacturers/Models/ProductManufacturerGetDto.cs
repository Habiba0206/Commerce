using Commerce.Application.Products.Models;

namespace Commerce.Application.Manufacturers.Models;

public class ProductManufacturerGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } // Unique

    public ICollection<ProductCreateUpdateDto> Products { get; set; }
    public bool IsDeleted { get; set; }
}
