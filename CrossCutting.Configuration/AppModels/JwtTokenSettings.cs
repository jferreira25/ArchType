using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class JwtTokenSettings
    {
        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("validateClaimToken")]
        public string ValidateClaimToken { get; set; }
    }
}
