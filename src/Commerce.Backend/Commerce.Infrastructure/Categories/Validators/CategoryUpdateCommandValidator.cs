using Commerce.Application.Categories.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Categories.Validators;

public class CategoryUpdateCommandValidator : AbstractValidator<CategoryUpdateCommand>
{
    public CategoryUpdateCommandValidator()
    {
        RuleFor(x => x.CategoryCreateUpdateDto)
            .NotNull().WithMessage("CategoryDto cannot be null.")
            .SetValidator(new CategoryValidator());
    }
}