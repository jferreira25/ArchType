using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class RedisSettings
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("cacheExpirationMinutes")]
        public int CacheExpirationMinutes { get; set; }
    }
}
