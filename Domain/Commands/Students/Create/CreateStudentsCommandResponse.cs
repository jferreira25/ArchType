namespace Projeto.Base.Domain.Commands.Students.Create
{
    public class CreateStudentsCommandResponse
    {
        public CreateStudentsCommandResponse(long id)
        {
            this.id = id;
        }

        public long id { get; set; }
    }
}
