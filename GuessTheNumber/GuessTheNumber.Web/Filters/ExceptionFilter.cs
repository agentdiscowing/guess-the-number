namespace GuessTheNumber.Web.Filters
{
    using System.Net;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.Core.Resources;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var apiError = new ApiError(HttpStatusCode.InternalServerError, ErrorMessages.UnhandledException);

            if (exception is GuessTheNumberException || exception.InnerException is GuessTheNumberException)
            {
                var ex = (GuessTheNumberException)exception.InnerException ?? (GuessTheNumberException)exception;

                apiError.StatusCode = (HttpStatusCode)ex.Code;

                apiError.Message = ex.Message;
            }

            context.Result = new ObjectResult(new { apiError.Message })
            {
                StatusCode = (int)apiError.StatusCode
            };
        }
    }
}