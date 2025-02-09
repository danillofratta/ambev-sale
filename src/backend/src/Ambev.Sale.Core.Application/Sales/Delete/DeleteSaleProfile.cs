using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Application.Sales.Delete;
using Ambev.Sale.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Delete
{
    public class DeleteSaleProfile : Profile
    {
        public DeleteSaleProfile()
        {       
            CreateMap<DeleteSaleCommand, Ambev.Sale.Core.Domain.Entities.Sale>();
            CreateMap<Ambev.Sale.Core.Domain.Entities.Sale, DeleteSaleResult>();            
        }
    }
}
