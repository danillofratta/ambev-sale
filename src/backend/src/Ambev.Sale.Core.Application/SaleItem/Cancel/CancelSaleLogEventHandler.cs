using MediatR;
using Microsoft.Extensions.Logging;

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
