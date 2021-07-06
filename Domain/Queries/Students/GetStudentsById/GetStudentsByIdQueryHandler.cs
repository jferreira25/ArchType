using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Queries.Students.GetStudentsById
{
    public class GetStudentsByIdQueryHandler : IRequestHandler<GetStudentsByIdQuery, GetStudentsByIdQueryResponse>
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;
        public GetStudentsByIdQueryHandler(
            IStudentsRepository lessonsRepository,
            IMapper mapper
            )
        {
            _studentsRepository = lessonsRepository;
            _mapper = mapper;
        }


        public async Task<GetStudentsByIdQueryResponse> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentsRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetStudentsByIdQueryResponse>(students);
        }
    }
}
