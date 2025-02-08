using Ambev.Sale.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Dto;

public record CreateSaleItemDto
(
    string ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice ,
    decimal Discount ,
    decimal TotalPrice,
    SaleStatus Status 
);
