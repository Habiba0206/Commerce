using Commerce.Application.Sales.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sales.Queries;

public record SaleGetByIdQuery : IQuery<SaleGetDto?>
{
    public Guid SaleId { get; set; }
}
