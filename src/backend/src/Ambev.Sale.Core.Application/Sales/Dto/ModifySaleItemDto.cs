using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Dto;

public record ModifySaleItemDto
(
    Guid SaleId ,
    Guid Id,
    string ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice ,
    decimal Discount ,
    decimal TotalPrice,
    Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus Status 
);
