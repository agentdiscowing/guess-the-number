namespace GuessTheNumber.Web.Filters
{
    using GuessTheNumber.Core.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            int status = 500;

            string message = string.Empty;

            if (exception is GuessTheNumberException ex)
            {
                status = ex.Code;

                message = ex.Message;
            }

            context.Result = new ContentResult
            {
                Content = message,
                StatusCode = status
            };
        }
    }
}