﻿using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Get(
        Expression<Func<Category, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    ValueTask<Category?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Category>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Category> CreateAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Category> UpdateAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Category?> DeleteAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Category?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
