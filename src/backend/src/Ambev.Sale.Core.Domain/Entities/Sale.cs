using Ambev.Sale.Core.Domain.Common;
using Ambev.Sale.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Domain.Entities;

public class Sale : BaseEntity
{    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Number { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; } = SaleStatus.NotCancelled;
    public List<SaleItem> SaleItems { get; set; } = new()!;    
}

