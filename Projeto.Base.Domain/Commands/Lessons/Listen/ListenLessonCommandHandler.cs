using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Lessons.Listen
{
    public class ListenLessonCommandHandler : IRequestHandler<ListenLessonCommand, bool>
    { 
        public ListenLessonCommandHandler() { }
       
        public async Task<bool> Handle(ListenLessonCommand request, CancellationToken cancellationToken)
        {
            //todo código

            return await Task.FromResult(true); // remover caso tenha chamada async
        }
    }
}
