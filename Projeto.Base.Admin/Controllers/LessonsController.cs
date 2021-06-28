using Projeto.Base.Admin.Filter;
using Projeto.Base.Controllers;
using Projeto.Base.Domain.Commands.Lessons.Create;
using Projeto.Base.Domain.Commands.Lessons.Delete;
using Projeto.Base.Domain.Commands.Lessons.Update;
using Projeto.Base.Domain.Queries.Lessons.GetFilterAllLessons;
using Projeto.Base.Domain.Queries.Lessons.GetLessonsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Projeto.Base.Admin.Controllers
{
    [Route("api/lessons")]
    public class LessonsController : BaseController<LessonsController>
    {
        public LessonsController(IMediator mediatorService) : base(mediatorService)
        {
        }

        [HttpGet("filter")]
        [HeaderContext]
        public async Task<IActionResult> GetFilterAll(GetFilterAllLessonsQuery query)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(query));
        }

        [HttpPost]
        [HeaderContext]
        public async Task<IActionResult> CreateLessonsAsync([FromBody] CreateLessonsCommand command)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpGet("{id}")]
        [HeaderContext]
        public async Task<IActionResult> GetLesonsAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetLessonsByIdQuery(id)));
        }

        [HttpPut("{id}")]
        [HeaderContext]
        public async Task<IActionResult> UpdateLessonsAsync(long id,[FromBody] UpdateLessonsCommand command)
        {
            command.Id = id;
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpDelete("{id}")]
        [HeaderContext]
        public async Task<IActionResult> DeleteLessonsAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new DeleteLessonsCommand(id)));
        }
    }
}
