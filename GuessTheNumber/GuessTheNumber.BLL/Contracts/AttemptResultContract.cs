namespace GuessTheNumber.BLL.Contracts
{
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public class AttemptResultContract
    {
        public int Number { get; set; }

        public GameAttemptResults Result { get; set; }
    }
}