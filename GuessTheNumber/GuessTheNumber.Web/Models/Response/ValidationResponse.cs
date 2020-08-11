namespace GuessTheNumber.Web.Models.Response
{
    using System.Collections.Generic;
    using System.Net;

    public class ValidationResponse : ApiError
    {
        public ValidationResponse()
            : base(HttpStatusCode.BadRequest, "Validation errors occured")
        {
            this.ValidationErrors = new List<ValidationError>();
        }

        public IList<ValidationError> ValidationErrors { get; set; }
    }
}