using Newtonsoft.Json;

namespace Projeto.Base.Domain.Commands.Authentication.CreateToken
{
    public sealed class CreateTokenCommandResponse
    {
        public CreateTokenCommandResponse(string token)
        {
            Token = token;
        }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
