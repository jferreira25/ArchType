using Azure.Messaging.ServiceBus;
using Projeto.Base.CrossCutting.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto.Base.Infrastructure.Publisher.LessonQueue
{
    public class LessonTopicPublisher
    {
        public string TopicName => AppSettings.Settings.ServiceBusSettings.LessonTopicPub.TopicName;
        public string ConnectionId => AppSettings.Settings.ServiceBusSettings.LessonTopicPub.ConnectionString;

        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _clientSender;

        public LessonTopicPublisher()
        {
            _client = new ServiceBusClient(ConnectionId);
            _clientSender = _client.CreateSender(TopicName);
        }

        public async Task SendMessage(object messageBody)
        {
            string messagePayload = JsonSerializer.Serialize(messageBody);
            ServiceBusMessage message = new ServiceBusMessage(messagePayload);
            //modificar/remover caso nao necessite de header
            message.ApplicationProperties.Add("goals", "teste");

            await _clientSender.SendMessageAsync(message);

        }
    }
}
