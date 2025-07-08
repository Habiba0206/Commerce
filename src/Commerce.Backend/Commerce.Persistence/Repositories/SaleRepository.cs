using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories;

public class SaleRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Sale, AppDbContext>(appDbContext, cacheBroker),
    ISaleRepository
{
    public IQueryable<Sale> Get(
        Expression<Func<Sale, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions)
        .Include(s => s.Product);

    public ValueTask<Sale?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Sale>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Sale> CreateAsync(Sale entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) =>
        base.CreateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Sale> UpdateAsync(Sale entity, CommandOptions commandOptions, CancellationToken cancellationToken) =>
        base.UpdateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Sale?> DeleteAsync(Sale entity, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Sale?> DeleteByIdAsync(Guid id, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}