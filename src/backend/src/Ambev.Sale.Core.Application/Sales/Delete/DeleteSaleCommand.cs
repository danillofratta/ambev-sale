using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.Sales.Delete
{
    public class DeleteSaleCommand : IRequest<DeleteSaleResult>
    {
        public Guid Id { get; set; }
    }
}
