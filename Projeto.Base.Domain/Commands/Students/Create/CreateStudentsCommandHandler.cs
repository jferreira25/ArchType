
using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Dto;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Students.Create
{
    public class CreateStudentsCommandHandler : IRequestHandler<CreateStudentsCommand, CreateStudentsCommandResponse>
    {
        private readonly IStudentsLessonsProcedure _studentsLessonsProcedure;
        private readonly IMapper _mapper;
        public CreateStudentsCommandHandler(
            IStudentsLessonsProcedure studentsLessonsProcedure,
            IMapper mapper
            )
        {
            _studentsLessonsProcedure = studentsLessonsProcedure;
            _mapper = mapper;
        }
        public async Task<CreateStudentsCommandResponse> Handle(CreateStudentsCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<StudentsLessonsDto>(request);

            var id = await _studentsLessonsProcedure.AddAsync(student);

            return new CreateStudentsCommandResponse(id);
        }
    }
}
