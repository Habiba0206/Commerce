using Commerce.Application.Products.Commands;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Products.CommandHandlers;

public class ProductDeleteManyCommandHandler(
        IProductService productService)
        : ICommandHandler<ProductDeleteManyCommand, int>
{
    public async Task<int> Handle(ProductDeleteManyCommand request, CancellationToken ct)
    {
        var count = 0;

        foreach (var id in request.ProductIds)
        {
            var deleted = await productService.DeleteByIdAsync(id, cancellationToken: ct);
            if (deleted is not null) count++;
        }

        return count;
    }
}