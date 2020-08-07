namespace GuessTheNumber.BLL
{
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.Utils;

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        public ShortUserInfoContract Login(LoginUserContract creds)
        {
            var checkUser = this.userRepository.Find(u => u.Email == creds.Email).FirstOrDefault();

            if (checkUser == null || !PasswordHasher.Verify(creds.Password, checkUser.PasswordHash))
            {
                return null;
            }

            return new ShortUserInfoContract
            {
                Id = checkUser.Id,
                Username = checkUser.Username,
                Email = checkUser.Email
            };
        }

        public ShortUserInfoContract Register(NewUserContract newUser)
        {
            var checkUnique = this.userRepository.Find(u => u.Email == newUser.Email || u.Username == newUser.Username).FirstOrDefault();

            if (checkUnique != null)
            {
                return null;
            }

            var insertedUser = this.userRepository.Insert(new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                PasswordHash = PasswordHasher.Hash(newUser.Password)
            });

            this.userRepository.SaveChangesAsync();

            return new ShortUserInfoContract
            {
                Id = insertedUser.Id,
                Username = insertedUser.Username,
                Email = insertedUser.Email
            };
        }
    }
}