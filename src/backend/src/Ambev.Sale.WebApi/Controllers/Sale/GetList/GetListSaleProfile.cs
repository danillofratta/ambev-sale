﻿using Ambev.Sale.Core.Application.Sales.GetList;
using AutoMapper;

namespace Ambev.Sale.WebApi.Controllers.Sale.GetList;

public class GetListSaleProfile : Profile
{
    public GetListSaleProfile()
    {
        CreateMap<GetListSaleQueryResult, GetListSaleResponse>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));
    }
}

