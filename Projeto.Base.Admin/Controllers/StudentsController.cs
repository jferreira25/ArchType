using Projeto.Base.Admin.Filter;
using Projeto.Base.Controllers;
using Projeto.Base.Domain.Commands.Students.Create;
using Projeto.Base.Domain.Commands.Students.Generate;
using Projeto.Base.Domain.Queries.Students.ExportStudents;
using Projeto.Base.Domain.Queries.Students.GetAllStudents;
using Projeto.Base.Domain.Queries.Students.GetStudentsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Projeto.Base.Admin.Controllers
{
    [Route("api/students")]
    public class StudentsController : BaseController<StudentsController>
    {
        public StudentsController(IMediator mediatorService) : base(mediatorService)
        {
        }

        [HttpGet("filter")]
        [HeaderContext]
        public async Task<IActionResult> GetAll(GetAllStudentsQuery query)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(query));
        }

        [HttpPost]
        [HeaderContext]
        public async Task<IActionResult> CreateStudentsAsync([FromBody] CreateStudentsCommand command)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpPost("generate")]
        [HeaderContext]
        public async Task<IActionResult> GenerateStudentsAsync()
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GenerateStudentsCommand()));
        }

        [HttpGet("{id}")]
        [HeaderContext]
        public async Task<IActionResult> GetStudentsAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetStudentsByIdQuery(id)));
        }


        [HttpPut("{id}")]
        [HeaderContext]
        public async Task<IActionResult> UpdateStudentsAsync(long id, [FromBody] UpdateStudentsCommand command)
        {
            command.Id = id;
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }

        [HttpDelete("{id}")]
        [HeaderContext]
        public async Task<IActionResult> DeleteStudentsAsync(long id)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new DeleteStudentsCommand(id)));
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(ExportStudentsQuery query)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(query));
        }
    }
}
