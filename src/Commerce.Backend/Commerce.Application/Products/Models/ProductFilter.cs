using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Products.Models;

public class ProductFilter : FilterPagination
{
    public float? MinimumPrice { get; set; }
    public float? MaximumPrice { get; set; }

    public IReadOnlyCollection<Guid>? ProductManufacturerIds { get; init; } = [];
    public IReadOnlyCollection<Guid>? SectionIds { get; init; } = [];
    public IReadOnlyCollection<Guid>? CategoryIds { get; init; } = [];
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is ProductFilter filter &&
        filter.GetHashCode() == GetHashCode();
}
