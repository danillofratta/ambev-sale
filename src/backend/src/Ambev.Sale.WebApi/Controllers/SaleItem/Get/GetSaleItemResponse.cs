using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Infrastructure.ORN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.WebApi.Controllers.SaleItem.Get;

public class GetSaleItemResponse
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }

    public SaleItemStatus Status { get; set; }
}
