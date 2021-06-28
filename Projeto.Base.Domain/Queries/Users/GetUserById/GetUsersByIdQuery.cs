using MediatR;

namespace Projeto.Base.Domain.Queries.Users.GetUsersById
{
    public class GetUsersByIdQuery : IRequest<GetUsersByIdQueryResponse>
    {
        public long Id { get; set; }

        public GetUsersByIdQuery(long id)
        {
            Id = id;
        }
    }
}
