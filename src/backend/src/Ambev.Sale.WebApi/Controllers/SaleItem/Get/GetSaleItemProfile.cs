using Ambev.Sale.Core.Application.SalesItem.Get;
using AutoMapper;


namespace Ambev.Sale.WebApi.Controllers.SaleItem.Get
{
    public class GetSaleItemProfile : Profile
    {
       public GetSaleItemProfile()
        {
            CreateMap<GetSaleItemRequest, GetSaleItemQuery>();
            CreateMap<GetSaleItemQueryResult, GetSaleItemResponse>();
        }
    }
}
