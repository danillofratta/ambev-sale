using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Infrastructure.ORN.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemProfile : Profile
    {
        public CancelSaleItemProfile()
        {       
            CreateMap<CancelSaleItemCommand, Ambev.Sale.Infrastructure.ORN.Entities.SaleItem>();
            CreateMap<Ambev.Sale.Infrastructure.ORN.Entities.SaleItem, CancelSaleItemResult>();            
        }
    }
}
