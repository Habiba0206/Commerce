using AutoMapper;
using Commerce.Application.Categories.Commands;
using Commerce.Application.Categories.Models;
using Commerce.Application.Categories.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Categories.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Categories.CommandHandlers;

public class CategoryCreateCommandHandler(
    IMapper mapper,
    ICategoryService service,
    CategoryValidator validator) : ICommandHandler<CategoryCreateCommand, CategoryCreateUpdateDto>
{
    public async Task<CategoryCreateUpdateDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.CategoryCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Category>(request.CategoryCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<CategoryCreateUpdateDto>(created);
    }
}