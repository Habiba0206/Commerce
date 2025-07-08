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

public class CategoryUpdateCommandHandler(
    IMapper mapper,
    ICategoryService service,
    CategoryValidator validator) : ICommandHandler<CategoryUpdateCommand, CategoryCreateUpdateDto>
{
    public async Task<CategoryCreateUpdateDto> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.CategoryCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Category>(request.CategoryCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<CategoryCreateUpdateDto>(updated);
    }
}