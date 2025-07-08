using Commerce.Application.Sections.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sections.Commands;

public record SectionPatchCommand : ICommand<SectionPatchDto>
{
    public SectionPatchDto SectionPatchDto { get; set; } = null!;
}