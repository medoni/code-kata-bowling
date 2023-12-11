namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Definition of a bowling game engine
/// </summary>
public interface IBowlingGameEngine
{
    /// <summary>
    /// Information about the current score
    /// </summary>
    IBowlingScoringEngine Scores { get; }

    /// <summary>
    /// Information about the current throwing 
    /// </summary>
    IBowlingThrowEngine Throwing { get; }

    /// <summary>
    /// True when the game has been finished.
    /// </summary>
    bool IsFinished { get; }
}
