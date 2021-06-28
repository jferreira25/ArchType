using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class ServiceBusSettings
    {
        [JsonProperty("lessonQueuePub")]
        public AzureServicePubQueueSettings LessonQueuePub { get; set; }

        [JsonProperty("lessonTopicPub")]
        public AzureServicePubTopicSettings LessonTopicPub { get; set; }

        [JsonProperty("lessonQueueSub")]
        public AzureServiceSubQueueSettings LessonQueueSub { get; set; }

        [JsonProperty("lessonTopicQueueSub")]
        public AzureServiceTopicQueueSettings LessonTopicQueueSub { get; set; }
    }

    public class AzureServicePubQueueSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

    }

    public class AzureServiceSubQueueSettings : AzureServicePubQueueSettings
    {
        [JsonProperty("maxConcurrentCalls")]
        public int MaxConcurrentCalls { get; set; }

        [JsonProperty("autoComplete")]
        public bool AutoComplete { get; set; }

    }

    public class AzureServiceTopicQueueSettings : AzureServicePubQueueSettings
    {
        [JsonProperty("maxConcurrentCalls")]
        public int MaxConcurrentCalls { get; set; }

        [JsonProperty("autoComplete")]
        public bool AutoComplete { get; set; }

        [JsonProperty("topicName")]
        public string TopicName { get; set; }
    }

    public class AzureServicePubTopicSettings
    {
        [JsonProperty("topicName")]
        public string TopicName { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

    }
}
