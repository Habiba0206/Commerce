namespace Commerce.Application.Categories.Models;

public class CategoryPatchDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; } //Unique
}
