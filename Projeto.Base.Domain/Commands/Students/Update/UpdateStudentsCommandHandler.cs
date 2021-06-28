using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Students.Create
{
    public class UpdateStudentsCommandHandler : IRequestHandler<UpdateStudentsCommand, Unit>
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;
        public UpdateStudentsCommandHandler(
            IStudentsRepository studentsRepository,
            IMapper mapper
            )
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentsCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Entities.Students>(request);
            await _studentsRepository.UpdateAsync(student);

            return Unit.Value;
        }
    }
}
