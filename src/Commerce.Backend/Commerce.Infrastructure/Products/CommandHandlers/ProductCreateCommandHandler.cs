using AutoMapper;
using Commerce.Application.Products.Commands;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Products.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Products.CommandHandlers;

public class ProductCreateCommandHandler(
    IMapper mapper,
    IProductService productService,
    ProductValidator validator) : ICommandHandler<ProductCreateCommand, ProductCreateUpdateDto>
{
    public async Task<ProductCreateUpdateDto> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.ProductCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Product>(request.ProductCreateUpdateDto);
        var created = await productService.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<ProductCreateUpdateDto>(created);
    }
}