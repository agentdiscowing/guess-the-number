namespace GuessTheNumber.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class NewUserContract : IValidatableObject
    {
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Username must contain from 6 to 60 characters")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"\w+@[A-z]+\.([A-z]){2,4}")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must contain from 6 to 60 characters")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Password.Where(chr => char.IsDigit(chr)).Count() == Password.Length)
            {
                results.Add(new ValidationResult($"Password must contain at least 1 letter"));
            }

            return results;
        }
    }
}