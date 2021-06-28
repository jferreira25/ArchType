using System.Text.Json.Serialization;

namespace Projeto.Base.Domain.Queries
{
    public class BaseQuery
    {
        public int CurrentPage { get; set; }
        public int PageLength { get; set; }
        [JsonIgnore]
        public int Offset
        {
            get => CurrentPage * PageLength;
        }
    }
}
