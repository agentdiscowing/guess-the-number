namespace GuessTheNumber.Web.Filters
{
    using System.Net;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var apiError = new ApiError(HttpStatusCode.InternalServerError, ErrorMessages.UnhandledException);

            if (exception is GuessTheNumberException ex)
            {
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