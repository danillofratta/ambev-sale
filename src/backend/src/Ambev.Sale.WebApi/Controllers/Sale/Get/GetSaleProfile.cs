using Ambev.Sale.Core.Application.Sales.Get;
using AutoMapper;

namespace Ambev.Sale.WebApi.Controllers.Sale.Get
{
    public class GetSaleProfile : Profile
    {
       public GetSaleProfile()
        {
            CreateMap<GetSaleRequest, GetSaleQuery>();
            CreateMap<GetSaleQueryResult, GetSaleResponse>();
        }
    }
}
