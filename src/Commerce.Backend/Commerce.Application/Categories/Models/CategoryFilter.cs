using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Categories.Models;

public class CategoryFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is CategoryFilter filter &&
        filter.GetHashCode() == GetHashCode();
}