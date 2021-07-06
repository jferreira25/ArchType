using Projeto.Base.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Base.Domain.Queries.Students.ExportStudents
{
    public class ExportStudentsQueryResponse : DownloadResponse
    {
        public ExportStudentsQueryResponse(
            byte[] dataToDownload) : base(dataToDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Students")
        {
        }
    }
}
