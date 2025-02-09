using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Enum;

namespace Ambev.Sale.Core.Application.Sales.Dto;

public class GetSaleItemDto
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public SaleItemStatus Status { get; set; } = new();
}
