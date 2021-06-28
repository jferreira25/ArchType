using Projeto.Base.Admin.Filter;
using Projeto.Base.Controllers;
using Projeto.Base.Domain.Commands.Users.Create;
using Projeto.Base.Domain.Queries.Users.GetAllUsers;
using Projeto.Base.Domain.Queries.Users.GetUsersById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Projeto.Base.Admin.Controllers
{
    [Route("api/users")]
    
    public class UsersController : BaseController<UsersController>
    {
        public UsersController(IMediator mediatorService) : base(mediatorService)
        {
        }

        [HttpGet("filter")]
        [HeaderContext]
        public async Task<IActionResult> GetAll(GetAllUsersQuery query)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(query));
        }

        [HttpPost]
        [HeaderContext]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUsersCommand command)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpGet("{id}")]
        [HeaderContext]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetUsersByIdQuery(id)));
        }

  
        [HttpPut("{id}")]
        [HeaderContext]
        public async Task<IActionResult> UpdateUserAsync(long id,[FromBody] UpdateUsersCommand command)
        {
            command.Id = id;
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpDelete("{id}")]
        [HeaderContext]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new DeleteUsersCommand(id)));
        }
    }
}
