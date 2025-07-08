using AutoMapper;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Queries;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Manufacturers.Queries;

public class ProductManufacturerGetByIdQueryHandler(
    IMapper mapper,
    IProductManufacturerService service)
    : IQueryHandler<ProductManufacturerGetByIdQuery, ProductManufacturerGetDto>
{
    public async Task<ProductManufacturerGetDto> Handle(ProductManufacturerGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.ProductManufacturerId, cancellationToken: cancellationToken);
        return mapper.Map<ProductManufacturerGetDto>(result);
    }
}