namespace GuessTheNumber.Web.Models.Response
{
    using System.Net;

    public class ApiError
    {
        public ApiError(HttpStatusCode code, string message)
        {
            this.Message = message;
            this.StatusCode = code;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}