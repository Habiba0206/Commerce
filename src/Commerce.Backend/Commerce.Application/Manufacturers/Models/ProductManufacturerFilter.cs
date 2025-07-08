using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Manufacturers.Models;

public class ProductManufacturerFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is ProductManufacturerFilter filter &&
        filter.GetHashCode() == GetHashCode();
}