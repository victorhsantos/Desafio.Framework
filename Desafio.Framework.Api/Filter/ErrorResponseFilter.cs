using Desafio.Framework.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Desafio.Framework.Api.Filter
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var erroResponse = ErrorResponse.From(context.Exception);                       
            context.Result = new ObjectResult(erroResponse) { StatusCode = 500 };
        }
    }
}
