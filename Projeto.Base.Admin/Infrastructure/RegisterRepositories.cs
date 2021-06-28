using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Domain.Interfaces.Cosmos;
using Projeto.Base.Domain.Interfaces.Sql;
using Projeto.Base.Infrastructure.Data.Cosmos.Repository;
using Projeto.Base.Infrastructure.Data.Sql.Procedure.StudentsLessons;
using Projeto.Base.Infrastructure.Data.Sql.Repository.Lesson;
using Projeto.Base.Infrastructure.Data.Sql.Repository.Students;
using Projeto.Base.Infrastructure.Data.Sql.Repository.Users;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterRepositories
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ILessonsRepository), typeof(LessonsRepository));
            services.AddScoped(typeof(IStudentsRepository), typeof(StudentsRepository));
            services.AddScoped(typeof(IStudentsLessonsProcedure), typeof(StudentsLessonsProcedure));
            
            //adicionando repository do cosmos sempre como singleton
            services.AddSingleton<ITesteRepository, TesteRepository>();
        }
    }
}
