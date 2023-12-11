
namespace BowlingCodeKata.BowlingGame.Impl;

/// <summary>
/// Responsible for calculate the score for a bowling game
/// </summary>
public class BowlingScoreEngine : IBowlingScoringEngine
{
    private readonly FramesList _frames;

    internal BowlingScoreEngine(
        FramesList frames
    )
    {
        _frames = frames ?? throw new ArgumentNullException(nameof(frames));
    }

    /// <summary>
    /// Calculates the score of the bowling game
    /// </summary>
    public int CalculateScore()
    {
        var lastScoredFrame = GetScoredFrames()
            .LastOrDefault();

        if (lastScoredFrame == null) return 0;

        return lastScoredFrame.Score;
    }

    /// <summary>
    /// Returns the scored frames
    /// </summary>
    public IReadOnlyList<ScoredFrame> GetScoredFrames()
    {
        var scoredFrames = _frames
            .Select((frame, idx) => ScoredFrame.CalculateFrame(_frames, idx))
            .ToList();

        return scoredFrames;
    }
}
