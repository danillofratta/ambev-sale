using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ambev.Sale.Infrastructure.ORN;
using Ambev.Sale.Infrastructure.ORN.Common;
using Ambev.Sale.Infrastructure.ORN.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Sale.Core.Domain.Repository;

    //public class SaleRepository : RepositoryBase<Ambev.Sale.Core.Domain.Entities.Sale>
    public class SaleItemRepository : RepositoryBase<SaleItem>    
    {
        public SaleItemRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
        {
        }

    //public async Task<IEnumerable<Sale> GetAll()
    //{
    //    return await Task.Run(() => _AppDbContext.Product.ToListAsync());
    //}

    public async Task<Ambev.Sale.Infrastructure.ORN.Entities.SaleItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _DefaultDbContext.SaleItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    ////todo improve search by name
    //public async Task<List<SharedDatabase.Models.Product>> GetByName(string name)
    //{
    //    var productIds = await _RedisCacheService.GetSetMembersAsync("all:products");

    //    List<SharedDatabase.Models.Product> products = new List<SharedDatabase.Models.Product>();

    //    if (productIds.Any())
    //    {
    //        foreach (var id in productIds)
    //        {
    //            var product = await _RedisCacheService.GetAsync<SharedDatabase.Models.Product>($"product:{id}");
    //            if (product != null && product.Name.ToUpper().Contains(name.ToUpper()))
    //                products.Add(product);
    //        }
    //    }

    //    if (!products.Any())
    //    {
    //        products = await _AppDbContext.Product.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();

    //        foreach (var product in products)
    //        {
    //            await _RedisCacheService.SetAsync($"product:{product.Id}", product, TimeSpan.FromHours(1));
    //            await _RedisCacheService.AddToSetAsync("all:products", product.Id.ToString());
    //        }
    //    }


    //    return products;
    //}

    //public override async Task AfterSave(SharedDatabase.Models.Product obj)
    //{
    //    await _RedisCacheService.SetAsync($"product:{obj.Id}", obj, TimeSpan.FromHours(1));
    //    await _RedisCacheService.AddToSetAsync("all:products", obj.Id.ToString());
    //    base.AfterSave(obj);
    //}

    //public override async Task AfterUpdate(SharedDatabase.Models.Product obj)
    //{
    //    await _RedisCacheService.SetAsync($"product:{obj.Id}", obj, TimeSpan.FromHours(1));

    //    base.AfterUpdate(obj);
    //}

    //public override async Task BeforeUpdate(SharedDatabase.Models.Product obj)
    //{
    //    await _RedisCacheService.RemoveAsync($"product:{obj.Id}");

    //    base.BeforeUpdate(obj);
    //}

    //public override async Task AfterDelete(SharedDatabase.Models.Product obj)
    //{
    //    await _RedisCacheService.RemoveAsync($"product:{obj.Id}");
    //    await _RedisCacheService.RemoveFromSetAsync("all:products", obj.Id.ToString());


    //    base.AfterDelete(obj);
    //}


}

