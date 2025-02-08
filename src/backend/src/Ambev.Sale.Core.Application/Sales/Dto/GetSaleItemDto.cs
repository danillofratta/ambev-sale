using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Enum;

namespace Ambev.Sale.Core.Application.Sales.Dto;

public record GetSaleItemDto
(
    Guid SaleId ,
    Guid Id,
    string ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice ,
    decimal Discount ,
    decimal TotalPrice,
    SaleStatus Status 
);
