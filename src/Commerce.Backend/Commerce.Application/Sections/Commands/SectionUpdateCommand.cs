using Commerce.Application.Sections.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sections.Commands;

public record SectionUpdateCommand : ICommand<SectionCreateUpdateDto>
{
    public SectionCreateUpdateDto SectionCreateUpdateDto { get; set; }
}

