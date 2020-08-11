namespace GuessTheNumber.Web.Models.Response
{
    using GuessTheNumber.Core.Constants;
    using System.Collections.Generic;
    using System.Net;

    public class ValidationResponse : ApiError
    {
        public ValidationResponse()
            : base(HttpStatusCode.BadRequest, ErrorMessages.ValidationError)
        {
            this.ValidationErrors = new List<ValidationError>();
        }

        public IList<ValidationError> ValidationErrors { get; set; }
    }
}