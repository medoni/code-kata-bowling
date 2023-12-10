namespace BowlingCodeKata.BowlingGame;

public class BowlingException : Exception
{
    public BowlingException(string message) : base(message)
    {

    }

    public static BowlingException CreateGameHasFinished() =>
        new BowlingException("Game has finished.");
}
