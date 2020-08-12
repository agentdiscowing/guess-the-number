namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Request;

    public static partial class ConvertingExtensions
    {
        public static NewUserContract ToContract(this NewUserRequest newUserRequest)
        {
            return new NewUserContract
            {
                Email = newUserRequest.Email,
                Password = newUserRequest.Password,
                Username = newUserRequest.Username
            };
        }
    }
}