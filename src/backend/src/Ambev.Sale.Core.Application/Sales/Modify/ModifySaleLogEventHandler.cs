using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Modify
{

    public class ModifySaleLogEventHandler : INotificationHandler<ModifySaleResult>
    {
        private readonly ILogger<ModifySaleLogEventHandler> _logger;

        public ModifySaleLogEventHandler(ILogger<ModifySaleLogEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ModifySaleResult notification, CancellationToken cancellationToken)
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
