using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Dto;
using MediatR;

namespace Ambev.Sale.Core.Application.Sales.Get
{
    public class GetSaleQuery : IRequest<GetSaleQueryResult>
    {
        public Guid Id { get; set; }

        public GetSaleQuery(Guid id)
        {
            Id = id;
        }

    }
}
