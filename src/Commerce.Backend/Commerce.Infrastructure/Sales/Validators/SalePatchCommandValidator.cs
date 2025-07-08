using Commerce.Application.Sales.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Sales.Validators;

public class SalePatchCommandValidator : AbstractValidator<SalePatchCommand>
{
    public SalePatchCommandValidator()
    {
        RuleFor(x => x.SalePatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.SalePatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}