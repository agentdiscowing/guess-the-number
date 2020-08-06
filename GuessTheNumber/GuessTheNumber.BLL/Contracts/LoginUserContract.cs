namespace GuessTheNumber.BLL.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserContract
    {
        [Required]
        [RegularExpression(@"\w+@[A-z]+\.([A-z]){2,4}")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        public string Password { get; set; }
    }
}