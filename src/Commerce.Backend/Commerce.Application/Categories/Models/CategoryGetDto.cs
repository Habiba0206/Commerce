using Commerce.Application.Products.Models;

namespace Commerce.Application.Categories.Models;

public class CategoryGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } //Unique

    public ICollection<ProductCreateUpdateDto> Products { get; set; }
    public bool IsDeleted { get; set; }
}
