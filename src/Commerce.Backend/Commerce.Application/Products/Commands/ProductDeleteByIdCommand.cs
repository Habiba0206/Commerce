using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Products.Commands;

public record ProductDeleteByIdCommand : ICommand<bool>
{
    public Guid ProductId { get; set; }
}
