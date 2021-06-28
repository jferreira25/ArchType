using AutoMapper;
using Azure.Messaging.ServiceBus;
using Projeto.Base.Subscriber.Interfaces;
using System.Threading.Tasks;

namespace Projeto.Base.Subscriber
{
    public abstract class Subscriber<T> : IServiceBusConsumer
    {
  
        abstract public string TopicName { get;  }
        abstract public string ConnectionId { get;  }

        private  ServiceBusProcessorOptions _serviceBusProcessorOptions { get; set; }
        private readonly ServiceBusClient _client;
        private ServiceBusProcessor _processor;

        public Subscriber(ServiceBusProcessorOptions serviceBusOptions)
        {
            _serviceBusProcessorOptions = serviceBusOptions;
            _client = new ServiceBusClient(ConnectionId);
        }

        public async Task CloseQueueAsync()
        {
            await _processor.CloseAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
                await _processor.DisposeAsync().ConfigureAwait(false);

            if (_client != null)
                await _client.DisposeAsync().ConfigureAwait(false);
        }

        public async Task RegisterOnMessageHandlerAndReceiveMessages()
        {
            _processor = _client.CreateProcessor(TopicName, _serviceBusProcessorOptions);
            _processor.ProcessMessageAsync += ProcessMessagesAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;
            await _processor.StartProcessingAsync().ConfigureAwait(false);
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            return Task.CompletedTask;
        }

        public async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            try
            {
                var myPayload = args.Message.Body.ToObjectFromJson<T>();
                await ConsumeAsync(myPayload);
                await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                await args.DeadLetterMessageAsync(args.Message);
            }
        }

        public virtual Task ConsumeAsync(T obj)
        {
            return Task.FromResult(true);
        }
    }
}
