namespace BowlingCodeKata.BowlingGame.Impl;

/// <summary>
/// Responsible for handling a bowling game
/// </summary>
public class BowlingGameEngine : IBowlingGameEngine
{
    private readonly IBowlingScoringEngine _scoreEngine;
    private readonly IBowlingThrowEngine _throwEngine;

    internal BowlingGameEngine(
        IBowlingScoringEngine scoreEngine,
        IBowlingThrowEngine throwEngine
    )
    {
        _scoreEngine = scoreEngine ?? throw new ArgumentNullException(nameof(scoreEngine));
        _throwEngine = throwEngine ?? throw new ArgumentNullException(nameof(throwEngine));
    }

    /// <summary>
    /// Creates a new bowling game
    /// </summary>
    public static IBowlingGameEngine Create()
    {
        var frameList = new FramesList();

        var scoreEngine = new BowlingScoreEngine(frameList);
        var throwEngine = new BowlingThrowEngine(frameList);

        var game = new BowlingGameEngine(
            scoreEngine,
            throwEngine
        );

        return game;
    }

    /// <inheritdoc/>
    public IBowlingScoringEngine Scores => _scoreEngine;

    /// <inheritdoc/>
    public IBowlingThrowEngine Throwing => _throwEngine;

    /// <inheritdoc/>
    public bool IsFinished => _throwEngine.IsFinished;
}
