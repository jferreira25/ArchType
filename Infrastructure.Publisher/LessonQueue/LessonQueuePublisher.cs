using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Projeto.Base.CrossCutting.Configuration;
using System.Threading.Tasks;

namespace Projeto.Base.Infrastructure.Publisher.LessonQueue
{
    public class LessonQueuePublisher
    {
        public  string TopicName => AppSettings.Settings.ServiceBusSettings.LessonQueuePub.Name;
        public  string ConnectionId => AppSettings.Settings.ServiceBusSettings.LessonQueuePub.ConnectionString;

        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _clientSender;

        public LessonQueuePublisher()
        {
            _client = new ServiceBusClient(ConnectionId);
            _clientSender = _client.CreateSender(TopicName);
        }
        public async Task  PushQueue(object objetoEnvio)
        {
            var messageBody = JsonConvert.SerializeObject(objetoEnvio);
            ServiceBusMessage message = new ServiceBusMessage(messageBody);

            await _clientSender.SendMessageAsync(message);

        }
    }
}
