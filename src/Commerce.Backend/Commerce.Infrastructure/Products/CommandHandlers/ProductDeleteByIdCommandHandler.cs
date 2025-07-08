using Commerce.Application.Products.Commands;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Products.CommandHandlers;

public class ProductDeleteByIdCommandHandler(
    IProductService productService)
    : ICommandHandler<ProductDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(ProductDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await productService.DeleteByIdAsync(request.ProductId, cancellationToken: cancellationToken);
        return result is not null;
    }
}