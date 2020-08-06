namespace GuessTheNumber.BLL
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.DAL.Entities;

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        public bool Login(LoginUserContract creds)
        {
            var checkUser = this.userRepository.Find(u => u.Email == creds.Email).FirstOrDefault();

            if (checkUser == null)
            {
                return false;
            }

            // will add hasing later
            return checkUser.PasswordHash == creds.Password;
        }

        public LoginUserContract Register(NewUserContract newUser)
        {
            throw new NotImplementedException();
        }
    }
}