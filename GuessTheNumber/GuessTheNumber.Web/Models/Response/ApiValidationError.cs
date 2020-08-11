namespace GuessTheNumber.Web.Models.Response
{
    using System.Collections.Generic;
    using System.Net;
    using GuessTheNumber.Core.Constants;

    public class ApiValidationError : ApiError
    {
        public ApiValidationError()
            : base(HttpStatusCode.BadRequest, ErrorMessages.ValidationError)
        {
            this.ValidationErrors = new List<ValidationResult>();
        }

        public IList<ValidationResult> ValidationErrors { get; set; }
    }
}