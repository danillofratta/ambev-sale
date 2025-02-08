
using Ambev.Sale.Core.Domain.Entities.Common;
using Ambev.Sale.Core.Domain.Entities.Enum;

namespace Ambev.Sale.Core.Domain.Entities;

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

    public SaleItemStatus Status { get; set; }
}

