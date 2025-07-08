using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Exceptions;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Infrastructure.Countries.Services;

public class CountryService(
    ICountryRepository repository)
    : ICountryService
{
    public IQueryable<Country> Get(
        Expression<Func<Country, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Country> Get(
        CountryFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions).ApplyPagination(filter);

    public ValueTask<Country?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Country>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Country> CreateAsync(
        Country entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Country> UpdateAsync(
        Country entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) ?? throw new NotFoundException(nameof(Country), entity.Id);
        
        existing.Name = entity.Name;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Country> PatchAsync(
        CountryPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken)
                      ?? throw new NotFoundException(nameof(Country), patchDto.Id);
        
        if (patchDto.Name is not null) existing.Name = patchDto.Name;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Country?> DeleteAsync(
        Country entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Country?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}