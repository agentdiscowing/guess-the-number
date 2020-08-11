using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GuessTheNumber.Web.Models.Response
{
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