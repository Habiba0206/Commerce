using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Products.Models;

public class ProductFilter : FilterPagination
{
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
