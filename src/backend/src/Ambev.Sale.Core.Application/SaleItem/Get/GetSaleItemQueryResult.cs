using Ambev.Sale.Core.Application.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.SalesItem.Get
{
    public class GetSaleItemQueryResult
    {
        public Guid id { get; set; }
        public Guid SaleId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }

        public Ambev.Sale.Infrastructure.ORN.Enum.SaleItemStatus Status { get; set; }
    }
}
