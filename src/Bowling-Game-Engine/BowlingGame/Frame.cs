using System.Diagnostics;

namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Responsible for storing information about a bowling frame
/// </summary>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract class BaseFrame
{
    private readonly List<int> _throws;

    /// <summary>
    /// Returns the list of throwed pins in this frame
    /// </summary>
    public IReadOnlyList<int> Throws => _throws;

    /// <summary>
    /// Creates a new <see cref="BaseFrame"/>
    /// </summary>
    public BaseFrame()
    {
        _throws = new List<int>();
    }

    /// <summary>
    /// Returns true if more throws allowed
    /// </summary>
    public abstract bool CanThrow { get; }

    /// <summary>
    /// Returns true if the throw has been finished
    /// </summary>
    public abstract bool ThrowFinished { get; }

    /// <summary>
    /// Returns true if this is the last (10nth) frame
    /// </summary>
    public virtual bool IsLastFrame { get; }

    /// <summary>
    /// Returns true if this frame is a strike
    /// </summary>
    public bool IsStrike => _throws.Count == 1 && _throws.First() == 10;

    /// <summary>
    /// Returns true if this frame is a spare
    /// </summary>
    public bool IsSpare => _throws.Count == 2 && _throws.Sum() == 10;

    /// <summary>
    /// Creates a new frame
    /// </summary>
    public static BaseFrame Create(int frameCount)
    => frameCount switch
    {
        < 10 => new DefaultFrame(),
        10 => new LastFrame(),
        _ => throw new InvalidOperationException()
    };

    /// <summary>
    /// Adds the throwed pins to this frame
    /// </summary>
    public void AddThrow(int count)
    {
        if (ThrowFinished) throw new InvalidOperationException("Frame has been finished.");
        _throws.Add(count);
    }

    private string GetDebuggerDisplay()
    => $"CanThrow: {CanThrow}, ThrowFinished: {ThrowFinished}, IsLastFrame: {IsLastFrame}, Throws: {string.Join(",", _throws)}";
}

/// <summary>
/// Responsible for storing information about all frames except the last
/// </summary>
public class DefaultFrame : BaseFrame
{
    /// <inheritdoc/>
    public override bool CanThrow => true;

    /// <inheritdoc/>
    public override bool ThrowFinished
    {
        get
        {
            if (Throws.Count == 0) return false;
            if (Throws.Count == 2) return true;
            if (IsStrike) return true;

            return false;
        }
    }
}

/// <summary>
/// Responsible for storing information for the last (10nth) frame
/// </summary>
public class LastFrame : BaseFrame
{
    /// <inheritdoc/>
    public override bool IsLastFrame => true;

    /// <inheritdoc/>
    public override bool CanThrow => !ThrowFinished;

    /// <inheritdoc/>
    public override bool ThrowFinished
    {
        get
        {
            if (Throws.Count == 0) return false;
            if (Throws.Count == 1) return false;
            if (Throws.Count == 3) return true;

            if (Throws.Take(2).Sum() < 10) return true;
            if (Throws.Take(2).Sum() == 20) return true;

            return false;
        }
    }
}