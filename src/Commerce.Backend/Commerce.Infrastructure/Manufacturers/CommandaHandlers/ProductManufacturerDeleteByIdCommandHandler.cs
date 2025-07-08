using Commerce.Application.Manufacturers.Commands;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Manufacturers.CommandaHandlers;

public class ProductManufacturerDeleteByIdCommandHandler(
    IProductManufacturerService service)
    : ICommandHandler<ProductManufacturerDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(ProductManufacturerDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.ProductManufacturerId, cancellationToken: cancellationToken);
        return result is not null;
    }
}