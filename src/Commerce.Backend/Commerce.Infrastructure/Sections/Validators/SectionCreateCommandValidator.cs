using Commerce.Application.Sections.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Sections.Validators;

public class SectionCreateCommandValidator : AbstractValidator<SectionCreateCommand>
{
    public SectionCreateCommandValidator()
    {
        RuleFor(x => x.SectionCreateUpdateDto)
            .NotNull().WithMessage("SectionDto cannot be null.")
            .SetValidator(new SectionValidator());
    }
}