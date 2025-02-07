using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Infrastructure.ORN.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Get
{
    public class GetSaleQueryProfile : Profile
    {
        public GetSaleQueryProfile()
        {
            CreateMap<Ambev.Sale.Infrastructure.ORN.Entities.Sale, GetSaleQueryResult>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));

        }
    }
}
