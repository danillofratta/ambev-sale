using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Create
{

    public class CreateSaleLogEventHandler : INotificationHandler<CreateSaleResult>
    {
        public Task Handle(CreateSaleResult notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} " +
                    $"- {notification.Number} '");
            });
        }
    }
}
