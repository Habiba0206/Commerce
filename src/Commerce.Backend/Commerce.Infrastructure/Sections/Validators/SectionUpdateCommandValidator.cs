using Commerce.Application.Sections.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Sections.Validators;

public class SectionUpdateCommandValidator : AbstractValidator<SectionUpdateCommand>
{
    public SectionUpdateCommandValidator()
    {
        RuleFor(x => x.SectionCreateUpdateDto)
            .NotNull().WithMessage("SectionDto cannot be null.")
            .SetValidator(new SectionValidator());
    }
}