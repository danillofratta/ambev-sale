using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using FluentValidation.Validators;
using MediatR;

namespace Ambev.Sale.WebApi.Controllers.SaleItem.Get
{
    public class GetSaleItemRequest
    {
        public Guid  Id { get; set; }
    }
}
