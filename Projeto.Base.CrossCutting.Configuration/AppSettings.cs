using Projeto.Base.CrossCutting.Configuration.AppModels;
using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration
{
    public class AppSettings: Settings
    {
        public static AppSettings Settings => AppFileConfiguration<AppSettings>.Settings;

        [JsonProperty("Sqlconnections")]
        public SqlConnection Sqlconnections { get; set; }
        [JsonProperty("jwtTokenSettings")]
        public JwtTokenSettings JwtTokenSettings { get; set; }

        [JsonProperty("serviceBusSettings")]
        public ServiceBusSettings ServiceBusSettings { get; set; }

        [JsonProperty("cosmos")]
        public CosmosConnection Cosmos { get; set; }
    }
}
