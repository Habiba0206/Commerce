using Commerce.Application.Countries.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Countries.Validators;

public class CountryPatchCommandValidator : AbstractValidator<CountryPatchCommand>
{
    public CountryPatchCommandValidator()
    {
        RuleFor(x => x.CountryPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.CountryPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}