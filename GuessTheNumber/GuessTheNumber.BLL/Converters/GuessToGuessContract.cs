namespace GuessTheNumber.BLL.Converters
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.DAL.Entities;

    public static partial class Converters
    {
        public static GuessContract ToContract(this Guess guess)
        {
            return new GuessContract
            {
                UserId = guess.UserId,
                Number = guess.Number,
                Username = guess.User.UserName
            };
        }
    }
}