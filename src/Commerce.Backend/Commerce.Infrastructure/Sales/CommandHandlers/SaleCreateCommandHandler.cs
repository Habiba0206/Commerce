using AutoMapper;
using Commerce.Application.Sales.Commands;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Sales.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Infrastructure.Sales.CommandHandlers;

public class SaleCreateCommandHandler(
    IMapper mapper,
    ISaleService service,
    SaleValidator validator) : ICommandHandler<SaleCreateCommand, SaleCreateUpdateDto>
{
    public async Task<SaleCreateUpdateDto> Handle(SaleCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.SaleCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Sale>(request.SaleCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<SaleCreateUpdateDto>(created);
    }
}
