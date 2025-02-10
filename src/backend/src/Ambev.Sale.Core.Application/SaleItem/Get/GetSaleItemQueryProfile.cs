using AutoMapper;

namespace Ambev.Sale.Core.Application.SalesItem.Get;

public class GetSaleItemQueryProfile : Profile
{
    public GetSaleItemQueryProfile()
    {
        CreateMap<Ambev.Sale.Core.Domain.Entities.SaleItem, GetSaleItemQueryResult>();               
    }
}

