using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ambev.Sale.Infrastructure.ORN;

//using Ambev.Sale.Core.Domain.Entities;
using Ambev.Sale.Infrastructure.ORN.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Sale.Core.Domain.Repository;

//public class SaleRepository : RepositoryBase<Ambev.Sale.Core.Domain.Entities.Sale>
public class SaleRepository : RepositoryBase<Ambev.Sale.Infrastructure.ORN.Entities.Sale>
{
    public SaleRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
    {
    }


    public async Task<Ambev.Sale.Infrastructure.ORN.Entities.Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _DefaultDbContext.Sales.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<(IReadOnlyList<Ambev.Sale.Infrastructure.ORN.Entities.Sale> sales, int totalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string orderBy,
        bool isDescending,
        CancellationToken cancellationToken)
    {
        // Inicia com a query base
        IQueryable<Ambev.Sale.Infrastructure.ORN.Entities.Sale> query = _DefaultDbContext.Sales;

        // Aplica ordenação dinâmica
        //if (!string.IsNullOrWhiteSpace(orderBy))
        //{
        //    // Converte a primeira letra para maiúscula para corresponder à propriedade
        //    var propertyName = char.ToUpper(orderBy[0]) + orderBy.Substring(1);

        //    try
        //    {
        //        query = isDescending
        //            ? query.OrderByDynamic(propertyName + " DESC")
        //            : query.OrderByDynamic(propertyName + " ASC");
        //    }
        //    catch
        //    {
        //        // Se a propriedade for inválida, usa ordenação padrão
        //        query = query.OrderByDescending(x => x.CreatedAt);
        //    }
        //}
        //else
        //{
        //    // Ordenação padrão se nenhuma for especificada
        //    query = query.OrderByDescending(x => x.CreatedAt);
        //}

        // Obtém o total de registros antes de aplicar a paginação
        var totalCount = await query.CountAsync(cancellationToken);

        // Aplica a paginação
        var sales = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (sales, totalCount);
    }

}

