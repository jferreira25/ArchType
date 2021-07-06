using System;

namespace Projeto.Base.Domain.Subscribers
{
    public class ImportedLesson
    {
        public Guid CorrelationId { get; set; }
        public string Mensagem { get; set; }
    }
}
