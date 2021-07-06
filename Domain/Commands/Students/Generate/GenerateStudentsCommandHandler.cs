using MediatR;
using Projeto.Base.Domain.Dto;
using Projeto.Base.Domain.Interfaces.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Students.Generate
{
    public class GenerateStudentsCommandHandler : IRequestHandler<GenerateStudentsCommand, Unit>
    {
    
        private readonly ILessonsRepository _lessonsRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IStudentsLessonsProcedure _studentsLessonsProcedure;

        public GenerateStudentsCommandHandler(
             ILessonsRepository lessonsRepository,
             IStudentsRepository studentsRepository,
             IStudentsLessonsProcedure studentsLessonsProcedure)
        {
            _lessonsRepository = lessonsRepository;
            _studentsRepository = studentsRepository;
            _studentsLessonsProcedure = studentsLessonsProcedure;
        }

        public async Task<Unit> Handle(GenerateStudentsCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
