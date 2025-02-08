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
        return await _DefaultDbContext.Sales.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<(IReadOnlyList<Ambev.Sale.Core.Domain.Entities.Sale> sales, int totalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string orderBy,
        bool isDescending,
        CancellationToken cancellationToken)
    {
        IQueryable<Ambev.Sale.Core.Domain.Entities.Sale> query = _DefaultDbContext.Sales;
        
        //if (!string.IsNullOrWhiteSpace(orderBy))
        //{
        //    Converte a primeira letra para maiúscula para corresponder à propriedade
        //    var propertyName = char.ToUpper(orderBy[0]) + orderBy.Substring(1);

        //    try
        //    {
        //        query = isDescending
        //            ? query.OrderByDynamic(propertyName + " DESC")
        //            : query.OrderByDynamic(propertyName + " ASC");
        //    }
        //    catch
        //    {
        //        Se a propriedade for inválida, usa ordenação padrão

        //       query = query.OrderByDescending(x => x.CreatedAt);
        //    }
        //}
        //else
        //{
        //    Ordenação padrão se nenhuma for especificada
        //   query = query.OrderByDescending(x => x.CreatedAt);
        //}

        var totalCount = await query.CountAsync(cancellationToken);

        var sales = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (sales, totalCount);
    }

}

