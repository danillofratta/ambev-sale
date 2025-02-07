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
    public class ModifySaleProfile : Profile
    {
        public ModifySaleProfile()
        {
        
            CreateMap<ModifySaleCommand, Ambev.Sale.Infrastructure.ORN.Entities.Sale>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));

            CreateMap<ModifySaleItemDto, Ambev.Sale.Infrastructure.ORN.Entities.SaleItem>();
            CreateMap< Ambev.Sale.Infrastructure.ORN.Entities.Sale, ModifySaleResult>();
        }
    }
}
