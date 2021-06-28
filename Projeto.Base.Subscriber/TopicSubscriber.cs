using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Projeto.Base.Subscriber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projeto.Base.Subscriber
{
    public abstract class TopicSubscriber<T> : IServiceBusTopicSubscription
    {
        abstract public string TopicName { get; }
        abstract public string Name { get; }
        abstract public string ConnectionId { get; }

        private ServiceBusProcessorOptions _serviceBusProcessorOptions { get; set; }
        private readonly ServiceBusClient _client;
        private ServiceBusProcessor _processor;
        private readonly ServiceBusAdministrationClient _adminClient;

        public TopicSubscriber(ServiceBusProcessorOptions serviceBusOptions)
        {
            _serviceBusProcessorOptions = serviceBusOptions;
            _client = new ServiceBusClient(ConnectionId);
            _adminClient = new ServiceBusAdministrationClient(ConnectionId);
        }

        public async Task CloseQueueAsync()
        {
            await _processor.CloseAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
            {
                await _processor.DisposeAsync().ConfigureAwait(false);
            }

            if (_client != null)
            {
                await _client.DisposeAsync().ConfigureAwait(false);
            }
        }

        public Task RegisterOnMessageHandlerAndReceiveMessages()
        {
            throw new NotImplementedException();
        }

        public async Task PrepareFiltersAndHandleMessages()
        {
            _processor = _client.CreateProcessor(TopicName, Name, _serviceBusProcessorOptions);
            _processor.ProcessMessageAsync += ProcessMessagesAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;

            await _processor.StartProcessingAsync().ConfigureAwait(false);
        }

        private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            try
            {
                var myPayload = args.Message.Body.ToObjectFromJson<T>();
                await ConsumeAsync(myPayload);
                await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
            }
            catch (Exception)
            {
                await args.DeadLetterMessageAsync(args.Message);
            }
        }

        public virtual Task ConsumeAsync(T obj)
        {
            return Task.FromResult(true);
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            return Task.CompletedTask;
        }

        public async Task RemoveDefaultFilters(string nameRemoveFilter)
        {
            var rules = _adminClient.GetRulesAsync(TopicName, Name);
            var ruleProperties = new List<RuleProperties>();

            await foreach (var rule in rules)
            {
                ruleProperties.Add(rule);
            }

            foreach (var rule in ruleProperties)
            {
                if (rule.Name == nameRemoveFilter.ToLower())
                {
                    await _adminClient.DeleteRuleAsync(TopicName, Name, nameRemoveFilter.ToLower())
                        .ConfigureAwait(false);
                }
            }
        }

        public async Task AddFilters(string filterName, SqlRuleFilter sqlRuleFilter)
        {
            var rules = _adminClient.GetRulesAsync(TopicName, Name)
                .ConfigureAwait(false);

            var ruleProperties = new List<RuleProperties>();
            await foreach (var rule in rules)
            {
                ruleProperties.Add(rule);
            }

            if (!ruleProperties.Any(r => r.Name == filterName.ToLower()))
            {
                CreateRuleOptions createRuleOptions = new CreateRuleOptions
                {
                    Name = filterName,
                    Filter = sqlRuleFilter
                };
                await _adminClient.CreateRuleAsync(TopicName, Name, createRuleOptions)
                    .ConfigureAwait(false);
            }
        }
    }
}