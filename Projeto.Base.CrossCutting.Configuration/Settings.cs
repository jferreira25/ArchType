using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration
{
    public class Settings
    {
        [JsonProperty(PropertyName = "applicationName")]
        public string ApplicationName { get; set; }
    }
}
