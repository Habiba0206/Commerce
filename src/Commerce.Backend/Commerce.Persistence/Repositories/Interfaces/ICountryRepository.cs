using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories.Interfaces;

public interface ICountryRepository
{
    IQueryable<Country> Get(
        Expression<Func<Country, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    ValueTask<Country?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Country>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Country> CreateAsync(
        Country country,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Country> UpdateAsync(
        Country country,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Country?> DeleteAsync(
        Country country,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Country?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
