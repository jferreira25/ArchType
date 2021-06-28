using AutoMapper;
using MediatR;
using Projeto.Base.Domain.Interfaces.Sql;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Users.Create
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUsersCommandHandler(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Entities.Users>(request);
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
