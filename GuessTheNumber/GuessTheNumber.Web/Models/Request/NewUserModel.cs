using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber.Web.Models.Request
{
    public class NewUserModel
    {
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Username must contain from 6 to 60 characters")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Entered email is invalid")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}