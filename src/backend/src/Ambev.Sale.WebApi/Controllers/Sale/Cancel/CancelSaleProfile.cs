using Ambev.Sale.Core.Application.Sales.Cancel;
using AutoMapper;

namespace Ambev.Sale.WebApi.Controllers.Sale.Cancel
{
    public class CancelSaleProfile : Profile
    {
       public CancelSaleProfile()
        {
            CreateMap<CancelSaleRequest, CancelSaleCommand>();
            CreateMap<CancelSaleResult, CancelSaleResponse>();
        }
    }
}
