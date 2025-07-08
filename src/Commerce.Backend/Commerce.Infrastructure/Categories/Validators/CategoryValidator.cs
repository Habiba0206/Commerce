using Commerce.Application.Categories.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Categories.Validators;

public class CategoryValidator : AbstractValidator<CategoryCreateUpdateDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required.");
    }
}