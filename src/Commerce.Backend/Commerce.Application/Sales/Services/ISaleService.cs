using Commerce.Application.Sales.Models;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Application.Sales.Services;

public interface ISaleService
{
    IQueryable<Sale> Get(
        Expression<Func<Sale, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<Sale> Get(
        SaleFilter filter, 
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
        Sale item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Sale> UpdateAsync(
        Sale item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Sale> PatchAsync(
        SalePatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Sale?> DeleteAsync(
        Sale item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Sale?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}