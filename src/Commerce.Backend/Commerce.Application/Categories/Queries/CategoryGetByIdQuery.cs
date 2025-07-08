using Commerce.Application.Categories.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Categories.Queries;

public record CategoryGetByIdQuery : IQuery<CategoryGetDto?>
{
    public Guid CategoryId { get; set; }
}