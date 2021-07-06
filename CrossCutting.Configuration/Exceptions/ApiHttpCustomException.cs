using System;
using System.Net;
using System.Net.Http;

namespace Projeto.Base.CrossCutting.Configuration.Exceptions
{
    public class ApiHttpCustomException : HttpRequestException
    {
        public HttpStatusCode ResponseCode { get; }

       
        public ApiHttpCustomException(string message, HttpStatusCode responseCode) : base(message)
        {
            ResponseCode = responseCode;
        }

        public ApiHttpCustomException(string message, HttpStatusCode responseCode, Exception innerException) : base(message, innerException)
        {
            ResponseCode = responseCode;
        }
    }
}