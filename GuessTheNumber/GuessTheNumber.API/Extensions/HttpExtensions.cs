namespace GuessTheNumber.API.Extensions
{
    using Microsoft.AspNetCore.Http;

    public static class HttpExtensions
    {
        public static int? GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return null;
            }

            return int.Parse(httpContext.User.FindFirst("id").Value);
        }
    }
}