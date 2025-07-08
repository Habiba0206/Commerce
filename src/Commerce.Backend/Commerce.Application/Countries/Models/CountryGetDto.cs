namespace Commerce.Application.Countries.Models;

public class CountryGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } //unique
    public bool IsDeleted { get; set; }
}
