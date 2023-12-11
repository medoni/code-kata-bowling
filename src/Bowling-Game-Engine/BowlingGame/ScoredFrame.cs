namespace BowlingCodeKata.BowlingGame;

public record ScoredFrame
{
    public bool IsLastFrame { get; }
    public IReadOnlyList<int> ThrowCount { get; }
    public int Score { get; }

    private ScoredFrame(
        bool isLastFrame,
        IEnumerable<int> throwCount,
        int score
    )
    {
        IsLastFrame = isLastFrame;
        ThrowCount = new List<int>(throwCount);
        Score = score;
    }

    public static ScoredFrame Empty => new ScoredFrame(false, Array.Empty<int>(), 0);

    public static ScoredFrame CalculateFrame(
        IReadOnlyList<BaseFrame> frames,
        int calculateForFrameIdx
    )
    {
        // TODO: Unit tests
        if (calculateForFrameIdx >= frames.Count) return Empty;

        var frame = frames[calculateForFrameIdx];
        var prevScore = calculateForFrameIdx > 0
            ? CalculateFrame(frames, calculateForFrameIdx - 1).Score
            : 0;

        var throws = frame.Throws;
        var score = throws.Sum();

        var nextFrame = frames.Skip(calculateForFrameIdx + 1).FirstOrDefault();
        var additions = frame.IsLastFrame
            ? CalculateSpecialAdditionsLastThrow(throws)
            : CalculateSpecialAdditions(frame, nextFrame);

        return new ScoredFrame(
            frame.IsLastFrame,
            throws,
            prevScore + score + additions
        );
    }

    internal static int CalculateSpecialAdditions(
        BaseFrame frame,
        BaseFrame? nextFrame
    )
    {
        if (nextFrame is null) return 0;

        if (frame.IsStrike)
        {
            return nextFrame.IsStrike
                ? 20
                : nextFrame.Throws.Sum();
        }

        if (frame.IsSpare)
        {
            return nextFrame.Throws.FirstOrDefault();
        }

        return 0;
    }

    internal static int CalculateSpecialAdditionsLastThrow(
        IEnumerable<int> throws
    )
    {
        var firstThrow = throws.FirstOrDefault();
        var secondThrow = throws.Skip(1).FirstOrDefault();
        var thirdThrow = throws.Skip(2).FirstOrDefault();

        if (firstThrow == 10) return secondThrow + thirdThrow;

        return 0;
    }
}
