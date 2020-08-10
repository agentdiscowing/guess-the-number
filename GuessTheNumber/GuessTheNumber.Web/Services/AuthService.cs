namespace GuessTheNumber.Web.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.Utils;
    using Microsoft.IdentityModel.Tokens;

    public class AuthService : IAuthService
    {
        private readonly string tokenKey;

        private readonly IRepository<User> userRepository;

        public AuthService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        public string Login(LoginUserContract creds)
        {
            var checkUser = this.userRepository.Find(u => u.Email == creds.Email).FirstOrDefault();

            if (checkUser == null)
            {
                throw new GuessTheNumberUserDoesNotExistException();
            }

            if (!PasswordHasher.Verify(creds.Password, checkUser.PasswordHash))
            {
                throw new GuessTheNumberInvalidPasswordException();
            }

            return this.Authenticate(new ShortUserInfoContract
            {
                Id = checkUser.Id,
                Username = checkUser.Username,
                Email = checkUser.Email
            });
        }

        public string Register(NewUserContract newUser)
        {
            var checkUnique = this.userRepository.Find(u => u.Email == newUser.Email || u.Username == newUser.Username).FirstOrDefault();

            if (checkUnique != null)
            {
                if (checkUnique.Email == newUser.Email)
                {
                    throw new GuessTheNumberEmailAlreadyExistsException();
                }

                throw new GuessTheNumberUsernameAlreadyExistsException();
            }

            var insertedUser = this.userRepository.Insert(new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                PasswordHash = PasswordHasher.Hash(newUser.Password)
            });

            this.userRepository.SaveChangesAsync();

            return this.Authenticate(new ShortUserInfoContract
            {
                Id = insertedUser.Id,
                Username = insertedUser.Username,
                Email = insertedUser.Email
            });
        }

        private string Authenticate(ShortUserInfoContract credentials)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username),
                    new Claim("id", credentials.Id.ToString()),
                    new Claim(ClaimTypes.Email, credentials.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}