using System.Threading.Tasks;

namespace Projeto.Base.Subscriber.Interfaces
{
    public interface IServiceBusTopicSubscription
    {
        Task PrepareFiltersAndHandleMessages();
        Task CloseQueueAsync();
        ValueTask DisposeAsync();

    }
}
