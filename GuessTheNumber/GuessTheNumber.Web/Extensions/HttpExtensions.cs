namespace GuessTheNumber.Web.Extensions
{
    using Microsoft.AspNetCore.Http;

    public static class HttpExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return null;
            }

            return httpContext.User.FindFirst("id").Value;
        }
    }
}