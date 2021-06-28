using MediatR;

namespace Projeto.Base.Domain.Commands.Users.Create
{
    public class UpdateUsersCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
    
    }
}
