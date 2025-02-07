using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Infrastructure.ORN.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Create
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
        
            CreateMap<CreateSaleCommand, Ambev.Sale.Infrastructure.ORN.Entities.Sale>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));                    

            CreateMap<CreateSaleItemDto, Ambev.Sale.Infrastructure.ORN.Entities.SaleItem>();

            CreateMap< Ambev.Sale.Infrastructure.ORN.Entities.Sale, CreateSaleResult>();
        }
    }
}
