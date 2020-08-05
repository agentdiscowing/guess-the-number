﻿namespace GuessTheNumber.DAL.Entities
{
    using System.Collections.Generic;

    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public virtual ICollection<Game> Games { get; set; }

    }
}