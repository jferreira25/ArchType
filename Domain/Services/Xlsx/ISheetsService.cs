using System.Collections.Generic;

namespace Projeto.Base.Domain.Services.Xlsx
{
    public interface ISheetsService
    {
        byte[] Generate(string sheetName, IEnumerable<object> objects);
    }
}
