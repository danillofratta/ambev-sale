using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class ModifySaleCommand : IRequest<ModifySaleResult>
    {
        public Guid id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus Status { get; set; }

        public List<ModifySaleItemDto> SaleItems { get; set; } = new();
    }
}
