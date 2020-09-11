namespace GuessTheNumber.Web.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.Web.Contracts;
    using GuessTheNumber.Web.Settings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    public class AuthService : IAuthService
    {
        private readonly JwtSettings jwtSettings;

        private readonly UserManager<IdentityUser> userManager;

        private readonly GameContext context;

        public AuthService(UserManager<IdentityUser> userRepo, JwtSettings jwtSettings, GameContext context)
        {
            this.userManager = userRepo;
            this.jwtSettings = jwtSettings;
            this.context = context;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
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

            return await this.Authenticate(new ShortUserInfoContract
            {
                Id = checkUser.Id,
                Username = checkUser.UserName,
                Email = checkUser.Email
            });
        }

        public async Task<AuthenticationResult> RegisterAsync(NewUserContract user)
        {
            var checkUniqueEmail = await this.userManager.FindByEmailAsync(user.Email);

            if (checkUniqueEmail != null)
            {
                throw new GuessTheNumberEmailAlreadyExistsException();
            }

            var checkUniqueUsername = await this.userManager.FindByNameAsync(user.Username);

            if (checkUniqueUsername != null)
            {
                throw new GuessTheNumberUsernameAlreadyExistsException();
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

            return await this.Authenticate(new ShortUserInfoContract
            {
                Id = newUser.Id,
                Username = newUser.UserName,
                Email = newUser.Email
            });
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = this.GetClaimsPrincipal(token);

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await this.context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                throw new GuessTheNumberRefreshTokenDoesNotExistException();
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                throw new GuessTheNumberRefreshTokenHasExpiredException();
            }

            if (storedRefreshToken.Invalidated)
            {
                throw new GuessTheNumberRefreshTokenIsInvalidatedException();
            }

            if (storedRefreshToken.Used)
            {
                throw new GuessTheNumberRefreshTokenIsUsedException();
            }

            if (storedRefreshToken.JwtId != jti)
            {
                throw new GuessTheNumberRefreshTokenWrongIdException();
            }

            storedRefreshToken.Used = true;
            this.context.RefreshTokens.Update(storedRefreshToken);
            await this.context.SaveChangesAsync();

            var user = await this.userManager.FindByIdAsync(principal.Claims.Single(x => x.Type == "id").Value);

            return await this.Authenticate(new ShortUserInfoContract
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email
            });
        }

        private async Task<AuthenticationResult> Authenticate(ShortUserInfoContract credentials)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username),
                    new Claim("id", credentials.Id),
                    new Claim(ClaimTypes.Email, credentials.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.Add(this.jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jwtSettings.TokenKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = credentials.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await this.context.RefreshTokens.AddAsync(refreshToken);
            await this.context.SaveChangesAsync();

            return new AuthenticationResult
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }

        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.TokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                }, out var validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}