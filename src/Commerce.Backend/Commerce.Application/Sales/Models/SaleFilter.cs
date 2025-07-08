using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sales.Models;

public class SaleFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is SaleFilter filter &&
        filter.GetHashCode() == GetHashCode();
}