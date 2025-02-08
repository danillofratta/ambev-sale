
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Infrastructure.Common;
using Ambev.Sale.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Sale.Infrastructure.Repository;

public class SaleItemRepository : RepositoryBase<Ambev.Sale.Core.Domain.Entities.SaleItem>, ISaleItemRepository
{
    public SaleItemRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
    {
    }

    public async Task<Ambev.Sale.Core.Domain.Entities.SaleItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _DefaultDbContext.SaleItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

}

