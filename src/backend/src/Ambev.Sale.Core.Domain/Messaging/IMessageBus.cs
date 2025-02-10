using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Domain.Messaging
{
    /// <summary>
    /// interface to publish and receive notifications/messages
    /// </summary>
    public interface IMessageBus
    {
        Task PublishEvent<T>(T @event) where T : class;
        Task SendCommand<T>(T command) where T : class;
    }
}
