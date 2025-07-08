using Commerce.Application.Categories.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Categories.Queries;

public record CategoryGetQuery : IQuery<ICollection<CategoryGetDto>>
{
    public CategoryFilter CategoryFilter { get; set; }
}