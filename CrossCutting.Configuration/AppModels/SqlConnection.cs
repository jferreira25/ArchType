using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class SqlConnection
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
    }
}
