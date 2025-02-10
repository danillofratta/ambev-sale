
using AutoMapper;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemProfile : Profile
    {
        public CancelSaleItemProfile()
        {       
            CreateMap<CancelSaleItemCommand, Ambev.Sale.Core.Domain.Entities.SaleItem>();
            CreateMap<Ambev.Sale.Core.Domain.Entities.SaleItem, CancelSaleItemResult>();            
        }
    }
}
