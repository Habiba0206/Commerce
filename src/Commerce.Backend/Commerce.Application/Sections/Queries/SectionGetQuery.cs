using Commerce.Application.Sections.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sections.Queries;

public record SectionGetQuery : IQuery<ICollection<SectionGetDto>>
{
    public SectionFilter SectionFilter { get; set; }
}
