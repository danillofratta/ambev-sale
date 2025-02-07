using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

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
