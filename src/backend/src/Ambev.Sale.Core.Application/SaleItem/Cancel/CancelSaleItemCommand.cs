﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
    {
        public Guid id { get; set; }
    }
}
