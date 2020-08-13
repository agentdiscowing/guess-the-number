namespace GuessTheNumber.Core.Enums
{
    public class GameLogicEnums
    {
        public enum GameAttemptResults
        {
            LESS = -1,
            MORE = 1,
            WIN = 0
        }

        public enum GameStates
        {
            ACTIVE,
            WON,
            OVER
        }
    }
}