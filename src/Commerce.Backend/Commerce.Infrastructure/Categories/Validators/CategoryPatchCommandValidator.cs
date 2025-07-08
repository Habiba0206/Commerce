using Commerce.Application.Categories.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Categories.Validators;

public class CategoryPatchCommandValidator : AbstractValidator<CategoryPatchCommand>
{
    public CategoryPatchCommandValidator()
    {
        RuleFor(x => x.CategoryPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.CategoryPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}