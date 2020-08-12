namespace GuessTheNumber.Web.Filters
{
    using System.Linq;
    using System.Threading.Tasks;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var validationResponse = new ApiValidationError();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        validationResponse.ValidationErrors.Add(new ValidationResult
                        {
                            Field = error.Key,
                            Message = subError
                        });
                    }
                }

                context.Result = new ObjectResult(new { validationResponse.Message, validationResponse.ValidationErrors })
                {
                    StatusCode = (int)validationResponse.StatusCode
                };

                return;
            }

            await next();
        }
    }
}