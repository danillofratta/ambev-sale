using Ambev.Sale.Core.Domain;

namespace Ambev.Sale.Core.Domain.Repository;

public interface ISaleItemRepository  : IRepositoryBase<Ambev.Sale.Core.Domain.Entities.SaleItem>
{
    /// <summary>
    /// Returns the sales item from the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Ambev.Sale.Core.Domain.Entities.SaleItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);    
}

