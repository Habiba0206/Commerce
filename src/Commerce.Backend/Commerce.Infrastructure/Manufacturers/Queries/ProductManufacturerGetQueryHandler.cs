using AutoMapper;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Queries;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Manufacturers.Queries;

public class ProductManufacturerGetQueryHandler(
    IMapper mapper,
    IProductManufacturerService service,
    GetQueryValidator validationRules)
    : IQueryHandler<ProductManufacturerGetQuery, ICollection<ProductManufacturerGetDto>>
{
    public async Task<ICollection<ProductManufacturerGetDto>> Handle(ProductManufacturerGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.ProductManufacturerFilter ?? new ProductManufacturerFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.ProductManufacturerFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<ProductManufacturerGetDto>>(result);
    }
}