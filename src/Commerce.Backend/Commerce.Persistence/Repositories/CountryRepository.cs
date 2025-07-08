using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories;

public class CountryRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Country, AppDbContext>(appDbContext, cacheBroker),
    ICountryRepository
{
    public IQueryable<Country> Get(
        Expression<Func<Country, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Country?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Country>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Country> CreateAsync(Country entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) =>
        base.CreateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Country> UpdateAsync(Country entity, CommandOptions commandOptions, CancellationToken cancellationToken) =>
        base.UpdateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Country?> DeleteAsync(Country entity, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Country?> DeleteByIdAsync(Guid id, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}