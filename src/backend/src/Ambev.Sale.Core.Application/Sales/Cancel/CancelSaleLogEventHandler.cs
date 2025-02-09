using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Cancel
{

    public class CancelSaleLogEventHandler : INotificationHandler<CancelSaleResult>
    {
        private readonly ILogger<CancelSaleLogEventHandler> _logger;

        public CancelSaleLogEventHandler(ILogger<CancelSaleLogEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CancelSaleResult notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation(
                   $"Cancel: '{notification.id} ");

                Console.WriteLine($"Cancel: '{notification.id} " );
            });
        }
    }
}
