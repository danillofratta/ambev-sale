using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Get;

public class GetSaleQueryResult
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; } 
    public string BranchId { get; set; }
    public string BranchName { get; set; } 

    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public List<GetSaleItemDto> SaleItems { get; set; } 
}

