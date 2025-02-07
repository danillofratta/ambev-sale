using Ambev.Sale.Core.Application.SaleItem.Cancel;
using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using AutoMapper;

namespace Ambev.Sale.WebApi.Controllers.SaleItem.Cancel
{
    public class CancelSaleItemProfile : Profile
    {
       public CancelSaleItemProfile()
        {
            CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>();
            CreateMap<CancelSaleItemResult, CancelSaleItemResponse>();
        }
    }
}
