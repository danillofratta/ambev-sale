using Ambev.Sale.Core.Domain;

namespace Ambev.Sale.Core.Domain.Repository;

public interface ISaleItemRepository  : IRepositoryBase<Ambev.Sale.Core.Domain.Entities.SaleItem>
{
    Task<Ambev.Sale.Core.Domain.Entities.SaleItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);    
}

