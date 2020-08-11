﻿namespace GuessTheNumber.Web.Services
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
    using GuessTheNumber.Web.Settings;

    public class AuthService : IAuthService
    {
        private readonly JwtSettings jwtSettings;

        private readonly IRepository<User> userRepository;

        public AuthService(IRepository<User> userRepo, JwtSettings jwtSettings)
        {
            this.userRepository = userRepo;
            this.jwtSettings = jwtSettings;
        }

        public string Login(string email, string password)
        {
            var checkUser = this.userRepository.Find(u => u.Email == email).FirstOrDefault();

            if (checkUser == null)
            {
                throw new GuessTheNumberUserDoesNotExistException();
            }

            if (!PasswordHasher.Verify(password, checkUser.PasswordHash))
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
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username),
                    new Claim("id", credentials.Id.ToString()),
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