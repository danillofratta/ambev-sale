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
            CreateMap <Ambev.Sale.Core.Domain.Entities.Sale, GetSaleQueryResult>()
               .ForMember(dto => dto.Id, conf => conf.MapFrom(s => s.Id)) 
               .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(s => s.SaleItems));

            CreateMap<Ambev.Sale.Core.Domain.Entities.SaleItem, GetSaleItemDto>();
        }
    }
}
