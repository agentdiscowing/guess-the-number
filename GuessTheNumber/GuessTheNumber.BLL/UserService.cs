namespace GuessTheNumber.BLL
{
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

        public bool Login(LoginUserContract creds)
        {
            var checkUser = this.userRepository.Find(u => u.Email == creds.Email).FirstOrDefault();

            if (checkUser == null)
            {
                return false;
            }

            return PasswordHasher.Verify(creds.Password, checkUser.PasswordHash);
        }

        public ShortUserInfoContract Register(NewUserContract newUser)
        {
            var checkUnique = this.userRepository.Find(u => u.Email == newUser.Email || u.Username == newUser.Username).FirstOrDefault();

            if (checkUnique != null)
            {
                return null;
            }

            this.userRepository.Insert(new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                PasswordHash = PasswordHasher.Hash(newUser.Password)
            });

            this.userRepository.SaveChangesAsync();

            return new ShortUserInfoContract
            {
                Email = newUser.Email,
                Username = newUser.Username
            };
        }
    }
}