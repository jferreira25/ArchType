using MediatR;

namespace Projeto.Base.Domain.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : BaseQuery, IRequest<GetAllUsersQueryResponse>
    {
        public string Name { get; set; }
    }
}
