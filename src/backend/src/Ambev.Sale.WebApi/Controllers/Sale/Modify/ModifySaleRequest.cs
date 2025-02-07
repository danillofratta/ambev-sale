using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using FluentValidation.Validators;
using MediatR;

namespace Ambev.Sale.WebApi.Controllers.Sale.Modify
{
    public class ModifySaleRequest
    {
        public Guid  Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public List<ModifySaleItemDto> SaleItems { get; set; } = new();
    }
}
