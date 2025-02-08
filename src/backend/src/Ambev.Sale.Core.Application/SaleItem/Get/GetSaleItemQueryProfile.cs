using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.SalesItem.Get;

public class GetSaleItemQueryProfile : Profile
{
    public GetSaleItemQueryProfile()
    {
        CreateMap<Ambev.Sale.Core.Domain.Entities.SaleItem, GetSaleItemQueryResult>();               
    }
}

