using Ambev.Sale.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Infrastructure.Common;

namespace Ambev.Sale.Infrastructure.Repository;

public class SaleRepository : RepositoryBase<Ambev.Sale.Core.Domain.Entities.Sale>, ISaleRepository
{
    public SaleRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
    {
    }

    public async Task<Ambev.Sale.Core.Domain.Entities.Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _DefaultDbContext.Sales.AsNoTracking().Include(s => s.SaleItems).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<(IReadOnlyList<Ambev.Sale.Core.Domain.Entities.Sale> sales, int totalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string orderBy,
        bool isDescending,
        CancellationToken cancellationToken)
    {
        //IQueryable<Ambev.Sale.Core.Domain.Entities.Sale> query = _DefaultDbContext.Sales;

        IQueryable<Ambev.Sale.Core.Domain.Entities.Sale> query = _DefaultDbContext.Sales
                    .Include(x => x.SaleItems)
                    .AsQueryable();

        // Apply ordering if specified
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            query = orderBy.ToLower() switch
            {
                "number" => isDescending
                    ? query.OrderByDescending(s => s.Number)
                    : query.OrderBy(s => s.Number),
                "customername" => isDescending
                    ? query.OrderByDescending(s => s.CustomerName)
                    : query.OrderBy(s => s.CustomerName),
                "totalamount" => isDescending
                    ? query.OrderByDescending(s => s.TotalAmount)
                    : query.OrderBy(s => s.TotalAmount),
                "date" => isDescending
                    ? query.OrderByDescending(s => s.CreatedAt)
                    : query.OrderBy(s => s.CreatedAt),
                _ => query.OrderByDescending(s => s.CreatedAt) // Default ordering
            };
        }
        else
        {
            // Default ordering if none specified
            query = query.OrderByDescending(s => s.CreatedAt);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

}

