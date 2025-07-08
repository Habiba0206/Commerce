using Commerce.Application.Manufacturers.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Manufacturers.Validators;

public class ProductManufacturerPatchCommandValidator : AbstractValidator<ProductManufacturerPatchCommand>
{
    public ProductManufacturerPatchCommandValidator()
    {
        RuleFor(x => x.ProductManufacturerPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.ProductManufacturerPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}