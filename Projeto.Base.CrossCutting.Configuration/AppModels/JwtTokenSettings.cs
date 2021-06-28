using Newtonsoft.Json;

namespace Projeto.Base.CrossCutting.Configuration.AppModels
{
    public class JwtTokenSettings
    {
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("expiration")]
        public int Expiration { get; set; }

        [JsonProperty("secretKey")]
        public string SecretKey { get; set; }
    }
}
