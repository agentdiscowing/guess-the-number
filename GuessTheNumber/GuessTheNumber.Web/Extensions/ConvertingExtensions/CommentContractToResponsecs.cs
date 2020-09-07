namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Response;

    public static partial class ConvertingExtensions
    {
        public static CommentResponse ToResponse(this CommentContract commentContract, string username)
        {
            return new CommentResponse
            {
                Username = commentContract.Username,
                Id = commentContract.Id,
                PostDate = commentContract.PostDate,
                Text = commentContract.Text,
                IsOwned = commentContract.Username == username
            };
        }
    }
}