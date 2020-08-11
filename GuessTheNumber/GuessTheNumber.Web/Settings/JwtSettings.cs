namespace GuessTheNumber.Web.Settings
{
    using System;

    public class JwtSettings
    {
        public string TokenKey { get; set; }

        public TimeSpan TokenLifetime { get; set; }
    }
}