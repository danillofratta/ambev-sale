using Ambev.Sale.Core.Application.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.GetList
{
    public class GetListSaleQueryResult
    {
        public Guid id { get; set; }
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public Ambev.Sale.Core.Domain.Enum.SaleStatus Status { get; set; }
        public List<GetSaleItemDto> SaleItems { get; set; }
    }
}
