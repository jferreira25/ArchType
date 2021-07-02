using FluentValidation;

namespace Projeto.Base.Domain.Commands.Lessons.Create
{
    public class CreateLessonsCommandValidator : AbstractValidator<CreateLessonsCommand>
    {
        public CreateLessonsCommandValidator()
        {
            RuleFor(lesson => lesson.Name).NotEmpty().WithMessage("matéria não pode estar vazio.");
            
        }
    }
}
