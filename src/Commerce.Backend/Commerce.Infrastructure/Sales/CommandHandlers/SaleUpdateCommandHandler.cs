using AutoMapper;
using Commerce.Application.Sales.Commands;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Sales.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Sales.CommandHandlers;

public class SaleUpdateCommandHandler(
    IMapper mapper,
    ISaleService service,
    SaleValidator validator) : ICommandHandler<SaleUpdateCommand, SaleCreateUpdateDto>
{
    public async Task<SaleCreateUpdateDto> Handle(SaleUpdateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.SaleCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Sale>(request.SaleCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<SaleCreateUpdateDto>(updated);
    }
}