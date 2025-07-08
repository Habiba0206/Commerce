using Commerce.Application.Countries.Models;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Application.Countries.Services;

public interface ICountryService
{
    IQueryable<Country> Get(
        Expression<Func<Country, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<Country> Get(
        CountryFilter filter, 
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
        Country item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Country> UpdateAsync(
        Country item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Country> PatchAsync(
        CountryPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Country?> DeleteAsync(
        Country item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Country?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}