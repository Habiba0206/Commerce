using Commerce.Application.Sales.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Sales.Queries;

public record SaleGetQuery : IQuery<ICollection<SaleGetDto>>
{
    public SaleFilter SaleFilter { get; set; }
}
