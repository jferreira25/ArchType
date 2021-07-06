using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class CosmosConnection
    {
        [JsonProperty("dbEndpoint")]
        public string DbEndpoint { get; set; }

        [JsonProperty("dbKey")]
        public string DbKey { get; set; }

        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }

        [JsonProperty("collectionName")]
        public string CollectionName { get; set; }
    }
}
