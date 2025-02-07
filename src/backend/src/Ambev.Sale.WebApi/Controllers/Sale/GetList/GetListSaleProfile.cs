using Ambev.Sale.Core.Application.Sales.GetList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ambev.Sale.WebApi.Controllers.Sale.GetList;

public class GetListSaleProfile : Profile
{
    public GetListSaleProfile()
    {
        CreateMap<GetListSaleQueryResult, GetListSaleResponse>()
                   .ForMember(dto => dto.SaleItems, conf => conf.MapFrom(ol => ol.SaleItems));
    }
}

