using Dapper;
using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.Domain.Dto;
using Projeto.Base.Domain.Interfaces.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Projeto.Base.Infrastructure.Data.Sql.Procedure.StudentsLessons
{
    public class StudentsLessonsProcedure : IStudentsLessonsProcedure
    {
        protected IDbConnection Connection => new SqlConnection(AppSettings.Settings.Sqlconnections.ConnectionString);
        public async Task<long> AddAsync(StudentsLessonsDto studentsLessons)
        {
            var values = new { StudentName = studentsLessons.StudentName, LessonId = studentsLessons.LessonId, SchoolGrades = studentsLessons.SchoolGrades };

            var id = Convert.ToInt64(await Connection.ExecuteScalarAsync("Insert_Students_And_Lessons", values, commandType: CommandType.StoredProcedure));

            return (long)id;
        }
    }
}
