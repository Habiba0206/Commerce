using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Products.Commands;

public record ProductDeleteManyCommand : ICommand<int>
{
    public IReadOnlyCollection<Guid> ProductIds { get; init; } = Array.Empty<Guid>();
}