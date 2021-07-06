using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(request);
            return _mapper.Map<GetAllUsersQueryResponse>(users);
        }
    }
}
