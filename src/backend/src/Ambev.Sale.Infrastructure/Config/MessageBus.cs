using Ambev.Sale.Core.Domain.Messaging;
using Rebus.Bus;

namespace Ambev.Sale.Infrastructure.Config
{    
    public class MessageBus : IMessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishEvent<T>(T @event) where T : class
        {
            await _bus.Publish(@event);
        }

        public async Task SendCommand<T>(T command) where T : class
        {
            await _bus.Send(command);
        }
    }
}
