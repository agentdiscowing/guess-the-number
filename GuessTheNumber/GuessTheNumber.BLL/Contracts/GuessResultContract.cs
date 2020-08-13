namespace GuessTheNumber.BLL.Contracts
{
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public class GuessResultContract
    {
        public int Number { get; set; }

        public GameAttemptResults Result { get; set; }
    }
}