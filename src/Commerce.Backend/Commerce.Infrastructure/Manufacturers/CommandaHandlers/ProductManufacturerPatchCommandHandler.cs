using AutoMapper;
using Commerce.Application.Manufacturers.Commands;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Manufacturers.CommandaHandlers;

public class ProductManufacturerPatchCommandHandler(
    IProductManufacturerService service,
    IMapper mapper)
    : ICommandHandler<ProductManufacturerPatchCommand, ProductManufacturerPatchDto>
{
    public async Task<ProductManufacturerPatchDto> Handle(ProductManufacturerPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.ProductManufacturerPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<ProductManufacturerPatchDto>(entity);
    }
}