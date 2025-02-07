using System.Collections.Generic;

namespace Ambev.Sale.Infrastructure.ORN.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AfterSaveAsync(TEntity obj);
        Task AfterUpdateAsync(TEntity obj);
        Task AfterDeleteAsync(TEntity obj);

        Task BeforeSaveAsync(TEntity obj);
        Task BeforeUpdateAsync(TEntity obj);
        Task BeforeDeleteAsync(TEntity obj);

        Task<TEntity> SaveAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
    }
}
