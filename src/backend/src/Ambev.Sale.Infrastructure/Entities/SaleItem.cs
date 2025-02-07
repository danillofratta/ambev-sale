
using Ambev.Sale.Infrastructure.ORN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Infrastructure.ORN.Entities;

public class SaleItem : BaseEntity
{
    public Guid SaleId { get; set; } 
    public Sale Sale { get; set; } = null!; 
    public string ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }

    public Ambev.Sale.Infrastructure.ORN.Enum.SaleItemStatus Status { get; set; }
}

