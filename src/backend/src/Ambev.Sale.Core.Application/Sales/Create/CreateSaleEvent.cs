using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Create
{
    public class CreateSaleEvent
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public string BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
