﻿namespace GuessTheNumber.Web.Models.Request
{
    public class RefreshTokenRequest
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}