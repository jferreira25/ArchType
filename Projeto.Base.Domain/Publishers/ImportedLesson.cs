using System;

namespace Projeto.Base.Domain.Publishers
{
    public class ImportedLesson
    {
        public Guid CorrelationId { get; set; }
        public string Mensagem { get; set; }
    }
}
