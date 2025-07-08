using AutoMapper;
using Commerce.Application.Sales.Commands;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Sales.CommandHandlers;

public class SalePatchCommandHandler(
    ISaleService service,
    IMapper mapper)
    : ICommandHandler<SalePatchCommand, SalePatchDto>
{
    public async Task<SalePatchDto> Handle(SalePatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.SalePatchDto, cancellationToken: cancellationToken);
        return mapper.Map<SalePatchDto>(entity);
    }
}