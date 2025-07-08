using Commerce.Application.Products.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Products.Commands;

public record ProductPatchCommand : ICommand<ProductPatchDto>
{
    public ProductPatchDto ProductPatchDto { get; set; } = null!;
}
