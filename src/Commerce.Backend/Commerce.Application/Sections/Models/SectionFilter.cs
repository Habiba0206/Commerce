using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sections.Models;

public class SectionFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is SectionFilter filter &&
        filter.GetHashCode() == GetHashCode();
}