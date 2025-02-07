using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Infrastructure.ORN.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleProfile : Profile
    {
        public CancelSaleProfile()
        {       
            CreateMap<CancelSaleCommand, Ambev.Sale.Infrastructure.ORN.Entities.Sale>();
            CreateMap<Ambev.Sale.Infrastructure.ORN.Entities.Sale, CancelSaleResult>();            
        }
    }
}
