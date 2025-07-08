using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories.Interfaces;

public interface ISaleRepository
{
    IQueryable<Sale> Get(
        Expression<Func<Sale, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    ValueTask<Sale?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Sale>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Sale> CreateAsync(
        Sale sale,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Sale> UpdateAsync(
        Sale sale,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Sale?> DeleteAsync(
        Sale sale,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Sale?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
