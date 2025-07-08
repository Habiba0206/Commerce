using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Countries.Models;

public class CountryFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is CountryFilter filter &&
        filter.GetHashCode() == GetHashCode();
}