using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Cancel
{
    public class CancelSaleProfile : Profile
    {
        public CancelSaleProfile()
        {       
            CreateMap<CancelSaleCommand, Ambev.Sale.Core.Domain.Entities.Sale>();
            CreateMap<Ambev.Sale.Core.Domain.Entities.Sale, CancelSaleResult>();            
        }
    }
}
