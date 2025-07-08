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

public class ProductUpdateCommandHandler(
    IMapper mapper,
    IProductService productService,
    ProductValidator validator) : ICommandHandler<ProductUpdateCommand, ProductCreateUpdateDto>
{
    public async Task<ProductCreateUpdateDto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.ProductCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Product>(request.ProductCreateUpdateDto);
        var updated = await productService.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<ProductCreateUpdateDto>(updated);
    }
}
