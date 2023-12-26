namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Contains Information about exceptions related to bowling
/// </summary>
public class BowlingException : Exception
{
    /// <summary>
    /// Creates a new <see cref="BowlingException"/>
    /// </summary>
    public BowlingException(string message) : base(message)
    {

    }

    internal static BowlingException CreateGameHasFinished() =>
        new BowlingException("Game has finished.");
}
