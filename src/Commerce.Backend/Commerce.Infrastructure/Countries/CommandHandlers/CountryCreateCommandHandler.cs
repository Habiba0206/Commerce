using AutoMapper;
using Commerce.Application.Countries.Commands;
using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Countries.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Countries.CommandHandlers;

public class CountryCreateCommandHandler(
    IMapper mapper,
    ICountryService service,
    CountryValidator validator) : ICommandHandler<CountryCreateCommand, CountryCreateUpdateDto>
{
    public async Task<CountryCreateUpdateDto> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.CountryCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Country>(request.CountryCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<CountryCreateUpdateDto>(created);
    }
}
