using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Queries.Users.GetUsersById
{
    public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQuery, GetUsersByIdQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUsersByIdQueryHandler(
            IUserRepository categoryRepository,
            IMapper mapper
            )
        {
            _userRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<GetUsersByIdQueryResponse> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetUsersByIdQueryResponse>(user);
        }
    }
}
