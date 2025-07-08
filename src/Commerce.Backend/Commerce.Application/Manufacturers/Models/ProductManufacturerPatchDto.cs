namespace Commerce.Application.Manufacturers.Models;

public class ProductManufacturerPatchDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; } // Unique
}
