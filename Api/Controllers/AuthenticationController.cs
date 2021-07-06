using Projeto.Base.Controllers;
using Projeto.Base.Domain.Commands.Authentication.CreateToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Projeto.Base.Admin.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        public AuthenticationController(IMediator mediatorService) : base(mediatorService)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateTokenCommand command)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }
    }
}
