using AutoMapper;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Queries;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Sales.QueryHandlers;

public class SaleGetByIdQueryHandler(
    IMapper mapper,
    ISaleService service)
    : IQueryHandler<SaleGetByIdQuery, SaleGetDto>
{
    public async Task<SaleGetDto> Handle(SaleGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.SaleId, cancellationToken: cancellationToken);
        return mapper.Map<SaleGetDto>(result);
    }
}