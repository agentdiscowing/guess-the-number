namespace GuessTheNumber.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

        public class RefreshToken
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Token { get; set; }

            public string JwtId { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime ExpiryDate { get; set; }

            public bool Used { get; set; }

            public bool Invalidated { get; set; }

            public string UserId { get; set; }

            public virtual IdentityUser User { get; set; }
        }
}