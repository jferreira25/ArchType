using System.Threading.Tasks;

namespace Projeto.Base.Subscriber.Interfaces
{
    public interface IServiceBusConsumer
    {
        Task RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseQueueAsync();
        ValueTask DisposeAsync();
    }
}
