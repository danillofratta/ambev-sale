using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.SalesItem.Get
{
    public class GetSaleItemQuery : IRequest<GetSaleItemQueryResult>
    {
        public Guid Id { get; set; }

        public GetSaleItemQuery(Guid id)
        {
            Id = id;
        }

    }
}
