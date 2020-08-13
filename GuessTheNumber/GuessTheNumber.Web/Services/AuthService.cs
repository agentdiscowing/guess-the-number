namespace GuessTheNumber.Web.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.Web.Contracts;
    using GuessTheNumber.Web.Settings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;

    public class AuthService : IAuthService
    {
        private readonly JwtSettings jwtSettings;

        private readonly UserManager<IdentityUser> userManager;

        public AuthService(UserManager<IdentityUser> userRepo, JwtSettings jwtSettings)
        {
            this.userManager = userRepo;
            this.jwtSettings = jwtSettings;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var checkUser = await this.userManager.FindByEmailAsync(email);
            if (checkUser == null)
            {
                throw new GuessTheNumberUserDoesNotExistException();
            }

            var passwordIsValid = await this.userManager.CheckPasswordAsync(checkUser, password);
            if (!passwordIsValid)
            {
                throw new GuessTheNumberInvalidPasswordException();
            }

            var token = this.Authenticate(new ShortUserInfoContract
            {
                Id = checkUser.Id,
                Username = checkUser.UserName,
                Email = checkUser.Email
            });

            return token;
        }

        public async Task<string> RegisterAsync(NewUserContract user)
        {
            var checkUniqueEmail = await this.userManager.FindByEmailAsync(user.Email);

            if (checkUniqueEmail != null)
            {
                throw new GuessTheNumberEmailAlreadyExistsException();
            }

            var newUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Email,
                Id = Guid.NewGuid().ToString()
            };

            var createdUser = await this.userManager.CreateAsync(newUser, user.Password);

            if (!createdUser.Succeeded)
            {
                throw new GuessTheNumberUserWasNotCreatedException();
            }

            var token = this.Authenticate(new ShortUserInfoContract
            {
                Id = newUser.Id,
                Username = newUser.UserName,
                Email = newUser.Email
            });

            return token;
        }

        private string Authenticate(ShortUserInfoContract credentials)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username),
                    new Claim("id", credentials.Id),
                    new Claim(ClaimTypes.Email, credentials.Email)
                }),
                Expires = DateTime.UtcNow.Add(this.jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jwtSettings.TokenKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}