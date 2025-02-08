using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Create
{

    public class CreateSaleLogEventHandler : INotificationHandler<CreateSaleResult>
    {
        private readonly ILogger<CreateSaleLogRebusHandler> _logger;

        public CreateSaleLogEventHandler(ILogger<CreateSaleLogRebusHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreateSaleResult notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation(
                   $"Created: '{notification.Id} " +
                    $"- {notification.Number} '");

                Console.WriteLine($"Created: '{notification.Id} " +
                    $"- {notification.Number} '");
            });
        }
    }
}
