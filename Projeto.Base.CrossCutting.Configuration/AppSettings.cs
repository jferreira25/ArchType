using Projeto.Base.CrossCutting.Configuration.AppModels;
using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration
{
    public class AppSettings: Settings
    {
        public static AppSettings Settings => AppFileConfiguration<AppSettings>.Settings;

        [JsonProperty("sqlconnections")]
        public SqlConnection Sqlconnections { get; set; }
        [JsonProperty("jwtTokenSettings")]
        public JwtTokenSettings JwtTokenSettings { get; set; }

        [JsonProperty("serviceBusSettings")]
        public ServiceBusSettings ServiceBusSettings { get; set; }

        [JsonProperty("cosmos")]
        public CosmosConnection Cosmos { get; set; }


        [JsonProperty("redis")]
        public RedisSettings Redis { get; set; }
    }
}
