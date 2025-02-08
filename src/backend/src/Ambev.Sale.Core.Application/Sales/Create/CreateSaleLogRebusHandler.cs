using Microsoft.Extensions.Logging;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.Create
{
    public class CreateSaleLogRebusHandler : IHandleMessages<CreateSaleEvent>
    {
        private readonly ILogger<CreateSaleLogRebusHandler> _logger;

        public CreateSaleLogRebusHandler(ILogger<CreateSaleLogRebusHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CreateSaleEvent message)
        {
            _logger.LogInformation(
                "Sale Created - Id: {Id}, Number: {Number}, Customer: {CustomerId}, Total: {Total}",
                message.Id,
                message.Number,
                message.CustomerId,
                message.TotalAmount);

            await Task.CompletedTask;
        }
    }
}
