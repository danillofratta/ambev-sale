﻿using Ambev.Sale.Core.Application.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Get
{
    public class GetSaleQueryResult
    {
        public Guid id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus Status { get; set; }

        public List<GetSaleItemDto> SaleItems { get; set; }
    }
}
