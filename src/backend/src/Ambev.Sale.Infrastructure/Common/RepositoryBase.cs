﻿using Ambev.Sale.Core.Domain;
using Ambev.Sale.Infrastructure.ORM;


namespace Ambev.Sale.Infrastructure.Common
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DefaultDbContext _DefaultDbContext;

        public RepositoryBase(DefaultDbContext defaultDbContext) 
        {
            _DefaultDbContext = defaultDbContext;
        }
        //protected readonly IRedisCacheService _RedisCacheService;

        //public RepositoryBase(DBDevContext appDbContext, IRedisCacheService redisCacheService)
        //{
        //    _AppDbContext = appDbContext;
        //    _RedisCacheService = redisCacheService;
        //}

        public virtual async Task BeforeSaveAsync(TEntity obj)
        {

        }

        public virtual async Task BeforeUpdateAsync(TEntity obj)
        {

        }

        public virtual async Task BeforeDeleteAsync(TEntity obj)
        {

        }

        public async Task<TEntity> SaveAsync(TEntity obj)
        {
            try
            {
                await BeforeSaveAsync(obj);
                await _DefaultDbContext.Set<TEntity>().AddAsync(obj);
                await _DefaultDbContext.SaveChangesAsync();
                await AfterSaveAsync(obj);
                return obj;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity obj)
        {
            try
            {
                await BeforeDeleteAsync(obj);
                _DefaultDbContext.Set<TEntity>().Remove(obj);
                await _DefaultDbContext.SaveChangesAsync();
                await AfterDeleteAsync(obj);

                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            try
            {
                await BeforeUpdateAsync(obj);
                _DefaultDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _DefaultDbContext.SaveChangesAsync();
                await AfterUpdateAsync(obj);

                return obj;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public virtual async Task AfterSaveAsync(TEntity obj)
        {
            
        }

        public virtual async Task AfterUpdateAsync(TEntity obj)
        {
            
        }

        public virtual async Task AfterDeleteAsync(TEntity obj)
        {
           
        }
    }
}
