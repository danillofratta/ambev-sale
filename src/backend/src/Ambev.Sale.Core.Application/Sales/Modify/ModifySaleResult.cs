using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class ModifySaleResult : INotification
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
