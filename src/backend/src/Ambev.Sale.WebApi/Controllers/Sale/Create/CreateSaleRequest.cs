using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using FluentValidation.Validators;
using MediatR;

namespace Ambev.Sale.WebApi.Controllers.Sale.Create
{
    public class CreateSaleRequest
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public List<CreateSaleItemDto> SaleItems { get; set; } = new();
    }
}
