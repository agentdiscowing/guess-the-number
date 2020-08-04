using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.DAL.Entities
{
    public class User: BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
