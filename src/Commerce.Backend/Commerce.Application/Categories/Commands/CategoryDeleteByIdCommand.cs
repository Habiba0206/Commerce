using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Categories.Commands;

public record CategoryDeleteByIdCommand : ICommand<bool>
{
    public Guid CategoryId { get; set; }
}
