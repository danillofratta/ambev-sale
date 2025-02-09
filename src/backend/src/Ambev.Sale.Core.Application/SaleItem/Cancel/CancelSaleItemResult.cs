using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemResult : INotification
    {
        public Guid id { get; set; }
    }
}
