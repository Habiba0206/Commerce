using AutoMapper;
using Commerce.Application.Manufacturers.Commands;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Manufacturers.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Manufacturers.CommandaHandlers;

public class ProductManufacturerCreateCommandHandler(
    IMapper mapper,
    IProductManufacturerService service,
    ProductManufacturerValidator validator) : ICommandHandler<ProductManufacturerCreateCommand, ProductManufacturerCreateUpdateDto>
{
    public async Task<ProductManufacturerCreateUpdateDto> Handle(ProductManufacturerCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.ProductManufacturerCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<ProductManufacturer>(request.ProductManufacturerCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<ProductManufacturerCreateUpdateDto>(created);
    }
}
