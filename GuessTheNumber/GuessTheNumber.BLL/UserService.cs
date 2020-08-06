namespace GuessTheNumber.BLL
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.Utils;

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        // change return type to some Result
        public bool Login(LoginUserContract creds)
        {
            var checkUser = this.userRepository.Find(u => u.Email == creds.Email).FirstOrDefault();

            if (checkUser == null)
            {
                return false;
            }

            return PasswordHasher.Verify(creds.Password, checkUser.PasswordHash);
        }

        public LoginUserContract Register(NewUserContract newUser)
        {
            throw new NotImplementedException();
        }
    }
}