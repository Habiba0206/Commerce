using Commerce.Application.Products.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Products.Validators;

public class ProductPatchCommandValidator : AbstractValidator<ProductPatchCommand>
{
    public ProductPatchCommandValidator()
    {
        RuleFor(x => x.ProductPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.ProductPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}