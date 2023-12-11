namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Definition for throwing pins for a bowling game
/// </summary>
public interface IBowlingThrowEngine
{
    /// <summary>
    /// Throws the given count of pins
    /// </summary>
    /// <exception cref="BowlingException">Thrown when the game has been finished.</exception>
    void Throw(int count);

    /// <summary>
    /// Returns true if the game has been finished.
    /// </summary>
    bool IsFinished { get; }
}
