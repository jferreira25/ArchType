using AutoMapper;
using MediatR;
using Projeto.Base.CrossCutting.Configuration;

namespace Projeto.Base.Infrastructure.Subscriber
{
    public class ImportedLessonSubscriber
    {
        public  string TopicName => AppSettings.Settings.ServiceBusSettings.LessonQueue.TopicName;
        public  string SubscriptionName => AppSettings.Settings.ServiceBusSettings.LessonQueue.Name;
        public  string ConnectionId => AppSettings.Settings.ServiceBusSettings.ConnectionString;

        public ImportedLessonSubscriber(IMediator mediator, IMapper mapper)
           : base(mediator, loggerFactory, mapper,
               new EventCustomSettings
               {
                   AzureServiceBusSettings = new AzureServiceBusSettings
                   {
                       AutoComplete = AppSettings.Settings.ServiceBusSettings.RulesDistribuiteQueue.AutoComplete,
                       MaxConcurrentCalls = AppSettings.Settings.ServiceBusSettings.RulesDistribuiteQueue.MaxConcurrentCalls,
                   }
               })
        {
            _mapper = mapper;
            _mediator = mediator;
           
        }

        public override async Task<ProcessedMessageResponse> ConsumeAsync(ImportedBooking message, IDictionary<string, object> headers, CancellationToken cancellationToken)
        {
            var customProperties = new Dictionary<string, object>();

            try
            {
                var processQueueDistributionCommand = _mapper.Map<ProcessQueueDistributionCommand>(message);

                _logger.LogInformation($"Start consuming message. Booking | CorrelationId: {message.CorrelationId} | RecordLocator: {processQueueDistributionCommand.RecordLocator}");

                await _mediator.Send(processQueueDistributionCommand, cancellationToken);

                _logger.LogInformation($"End consuming message. Booking | CorrelationId: {message.CorrelationId} | RecordLocator: {processQueueDistributionCommand.RecordLocator}");

                return new ProcessedMessageResponse(true);
            }
            catch (DatabaseException ex)
            {
                customProperties.Add("deadletterException", "DatabaseException");
                customProperties.Add("exception", ex.Message);

                _logger.LogError(ex, $@"Error processing Booking | 
                  CorrelationId: {message.CorrelationId} | RecordLocator: {message.RecordLocator} | Message: {JsonConvert.SerializeObject(message)}");
            }
            catch (Exception ex)
            {
                customProperties.Add("deadletterException", "ServiceException");
                customProperties.Add("exception", ex.Message);

                _logger.LogError(ex, $@"Error processing Booking | 
                    CorrelationId: {message.CorrelationId} | RecordLocator: {message.RecordLocator} | Message: {JsonConvert.SerializeObject(message)}");
            }

            return new ProcessedMessageResponse(false, customProperties);
        }
    }
}