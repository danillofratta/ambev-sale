using Ambev.Sale.Core.Application.Sales.Cancel;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{

    public class CancelSaleItemLogEventHandler : INotificationHandler<CancelSaleItemResult>
    {
        private readonly ILogger<CancelSaleItemLogEventHandler> _logger;

        public CancelSaleItemLogEventHandler(ILogger<CancelSaleItemLogEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CancelSaleItemResult notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation(
                   $"Created: '{notification.id} ");

                Console.WriteLine($"Created: '{notification.id} ");
            });
        }
    }
}
