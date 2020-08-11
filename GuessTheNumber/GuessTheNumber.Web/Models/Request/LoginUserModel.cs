namespace GuessTheNumber.Web.Models.Request
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Entered email is invalid")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        public string Password { get; set; }
    }
}