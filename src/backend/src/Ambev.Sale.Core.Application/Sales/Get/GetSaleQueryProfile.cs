using Ambev.Sale.Core.Application.Sales.Dto;
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
            CreateMap<Ambev.Sale.Core.Domain.Entities.Sale, GetSaleQueryResult>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));

        }
    }
}
