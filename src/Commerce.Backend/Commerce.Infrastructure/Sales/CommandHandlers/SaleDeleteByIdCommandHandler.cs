using Commerce.Application.Sales.Commands;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Sales.CommandHandlers;

public class SaleDeleteByIdCommandHandler(
    ISaleService service)
    : ICommandHandler<SaleDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(SaleDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.SaleId, cancellationToken: cancellationToken);
        return result is not null;
    }
}