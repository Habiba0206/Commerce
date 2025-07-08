using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sections.Commands;

public record SectionDeleteByIdCommand : ICommand<bool>
{
    public Guid SectionId { get; set; }
}
