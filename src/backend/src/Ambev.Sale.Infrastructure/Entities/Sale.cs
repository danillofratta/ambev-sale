using Ambev.Sale.Infrastructure.ORN.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Infrastructure.ORN.Entities;

public class Sale : BaseEntity
{
    public string CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus Status { get; set; } = Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus.NotCancelled;
    public List<SaleItem> SaleItems { get; set; } = new()!;    
}

