namespace Commerce.Application.Countries.Models;

public class CountryPatchDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; } //unique
}
