using Ambev.Sale.Core.Application.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.WebApi.Controllers.Sale.Get
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public List<GetSaleItemDto> Itens { get; set; }
    }
}
