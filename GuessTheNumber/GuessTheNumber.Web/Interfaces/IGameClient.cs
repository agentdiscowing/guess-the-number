namespace GuessTheNumber.Web.Interfaces
{
    using System.Threading.Tasks;

    public interface IGameClient
    {
        Task SendGameStartedMessage(string message);

        Task SendGameWonMessage(string message);

        Task SendGameOverMessage();
    }
}