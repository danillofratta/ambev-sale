using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleCommand : IRequest<CancelSaleResult>
    {
        public Guid id { get; set; }
    }
}
