using Moq;
using Projeto.Base.Domain.Entities;
using Projeto.Base.Domain.Interfaces.Sql;
using Projeto.Base.Domain.Queries.Users.GetAllUsers;
using Projeto.Base.Tests.Shared.Core;
using Projeto.Base.Tests.Shared.Mock.Domain.Entities.Users;
using System.Collections.Generic;

namespace Projeto.Base.Tests.Shared.Mock.Infrastructure.Database.Sql
{
    public class UsersRepositoryMock : BaseMock<IUserRepository>
    {
        public override Mock<IUserRepository> GetDefaultInstance()
        {
            UserRepository();
            return Mock;
        }

        private void UserRepository()
        {
            Setup(r => r.AddAsync(It.IsAny<Users>()), 1);
            Setup(r => r.UpdateAsync(It.IsAny<Users>()), true);
            Setup(r => r.DeleteAsync(It.IsAny<long>()), true);
            Setup(r => r.GetByIdAsync(It.IsAny<long>()), UsersMock.GetDefaultInstance());
            Setup(r => r.GetByUserAsync(It.IsAny<string>(), It.IsAny<string>()), UsersMock.GetDefaultInstance());
            Setup(r => r.GetAllAsync(It.IsAny<GetAllUsersQuery>()), new List<Users>());

        }
    }
}
