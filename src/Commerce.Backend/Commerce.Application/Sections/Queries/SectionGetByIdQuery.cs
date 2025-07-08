using Commerce.Application.Sections.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sections.Queries;

public record SectionGetByIdQuery : IQuery<SectionGetDto?>
{
    public Guid SectionId { get; set; }
}
