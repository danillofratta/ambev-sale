using Ambev.Sale.Core.Domain;

namespace Ambev.Sale.Core.Domain.Repository;

public interface ISaleRepository : IRepositoryBase<Ambev.Sale.Core.Domain.Entities.Sale>
{
    Task<Ambev.Sale.Core.Domain.Entities.Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<(IReadOnlyList<Ambev.Sale.Core.Domain.Entities.Sale> sales, int totalCount)> GetPagedAsync
        (
        int pageNumber,
        int pageSize,
        string orderBy,
        bool isDescending,
        CancellationToken cancellationToken
        );
}

