namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Responsible for storing information about the score of a single frame
/// </summary>
public record ScoredFrame
{
    /// <summary>
    /// True if this is the last frame
    /// </summary>
    public bool IsLastFrame { get; }

    /// <summary>
    /// The list of throws in this frame
    /// </summary>
    public IReadOnlyList<int> ThrowCount { get; }

    /// <summary>
    /// The calculated score of this frame
    /// </summary>
    public int Score { get; }

    /// <summary>
    /// Creates a new <see cref="ScoredFrame"/>
    /// </summary>
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

    /// <summary>
    /// Returns an empty scored frame
    /// </summary>
    public static ScoredFrame Empty => new ScoredFrame(false, Array.Empty<int>(), 0);

    /// <summary>
    /// Calculate a score for a given frame index and list of frames
    /// </summary>
    public static ScoredFrame CalculateFrame(
        IReadOnlyList<BaseFrame> frames,
        int calculateForFrameIdx
    )
    {
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

    /// <summary>
    /// Calculates additional scores for a given frame.
    /// Calculation is based on IsStrike and IsSpare and the next frame
    /// </summary>
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

    /// <summary>
    /// Calculates additional scores for the last frame
    /// </summary>
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
