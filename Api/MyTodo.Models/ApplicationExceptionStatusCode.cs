using System;
using System.Net;

namespace MyTodo.Models
{
    public abstract class ApplicationExceptionStatusCode : ApplicationException
    {
        public HttpStatusCode StatusCode { get; protected set; }

        public ApplicationExceptionStatusCode(string message, HttpStatusCode? statusCode) : base(message)
        {
            this.StatusCode = statusCode ?? HttpStatusCode.InternalServerError;
        }
    }
}