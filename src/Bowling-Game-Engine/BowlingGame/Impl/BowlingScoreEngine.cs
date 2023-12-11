
namespace BowlingCodeKata.BowlingGame.Impl;

public class BowlingScoreEngine : IBowlingScoringEngine
{
    private readonly FramesList _frames;

    internal BowlingScoreEngine(
        FramesList frames
    )
    {
        _frames = frames ?? throw new ArgumentNullException(nameof(frames));
    }

    public int CalculateScore()
    {
        var lastScoredFrame = GetScoredFrames()
            .LastOrDefault();

        if (lastScoredFrame == null) return 0;

        return lastScoredFrame.Score;
    }

    public IReadOnlyList<ScoredFrame> GetScoredFrames()
    {
        var scoredFrames = _frames
            .Select((frame, idx) => ScoredFrame.CalculateFrame(_frames, idx))
            .ToList();

        return scoredFrames;
    }
}
