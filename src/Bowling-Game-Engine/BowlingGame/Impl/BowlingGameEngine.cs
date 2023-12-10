namespace BowlingCodeKata.BowlingGame.Impl;

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

    public IBowlingScoringEngine Scores => _scoreEngine;
    public IBowlingThrowEngine Throwing => _throwEngine;

    public bool IsFinished => _throwEngine.IsFinished;
}
