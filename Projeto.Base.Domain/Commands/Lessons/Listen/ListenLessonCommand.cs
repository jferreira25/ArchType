using MediatR;
using System;

namespace Projeto.Base.Domain.Commands.Lessons.Listen
{
    public class ListenLessonCommand : IRequest<bool>
    {
        public string Mensagem { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
