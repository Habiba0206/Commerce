using AutoMapper;
using Commerce.Application.Products.Commands;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Products.CommandHandlers;

public class ProductPatchCommandHandler(
    IProductService productService,
    IMapper mapper)
    : ICommandHandler<ProductPatchCommand, ProductPatchDto>
{
    public async Task<ProductPatchDto> Handle(ProductPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await productService.PatchAsync(request.ProductPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<ProductPatchDto>(entity);
    }
}