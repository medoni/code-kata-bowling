
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
        throw new NotImplementedException();
    }
}
