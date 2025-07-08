using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories.Interfaces;

public interface IProductManufacturerRepository
{
    IQueryable<ProductManufacturer> Get(
        Expression<Func<ProductManufacturer, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    ValueTask<ProductManufacturer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<ProductManufacturer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<ProductManufacturer> CreateAsync(
        ProductManufacturer manufacturer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<ProductManufacturer> UpdateAsync(
        ProductManufacturer manufacturer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<ProductManufacturer?> DeleteAsync(
        ProductManufacturer manufacturer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<ProductManufacturer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
