using System.Diagnostics;

namespace BowlingCodeKata.BowlingGame;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract class BaseFrame
{
    private readonly List<int> _throws;
    public IReadOnlyList<int> Throws => _throws;

    public BaseFrame()
    {
        _throws = new List<int>();
    }

    public abstract bool CanThrow { get; }
    public abstract bool ThrowFinished { get; }
    public virtual bool IsLastFrame { get; }

    // todo: unit tests
    public bool IsStrike => _throws.Count == 1 && _throws.First() == 10;
    public bool IsSpare => _throws.Count == 2 && _throws.Sum() == 10;

    public static BaseFrame Create(int frameCount)
    => frameCount switch
    {
        < 10 => new DefaultFrame(),
        10 => new LastFrame(),
        _ => throw new InvalidOperationException()
    };

    public void AddThrow(int count)
    {
        if (ThrowFinished) throw new InvalidOperationException("Frame has been finished.");
        _throws.Add(count);
    }

    private string GetDebuggerDisplay()
    => $"CanThrow: {CanThrow}, ThrowFinished: {ThrowFinished}, IsLastFrame: {IsLastFrame}, Throws: {string.Join(",", _throws)}";
}


public class DefaultFrame : BaseFrame
{
    public override bool CanThrow => true;
    public override bool ThrowFinished
    {
        get
        {
            if (Throws.Count == 0) return false;
            if (Throws.Count == 2) return true;
            if (Throws.Last() < 10) return false;

            return true;
        }
    }
}

public class LastFrame : BaseFrame
{
    public override bool IsLastFrame => true;
    public override bool CanThrow => !ThrowFinished;
    public override bool ThrowFinished
    {
        get
        {
            // todo: refactor
            if (Throws.Count == 0) return false;
            if (Throws.Count == 1) return false;
            if (Throws.Count == 3) return true;

            if (Throws.Take(2).Sum() < 10) return true;
            if (Throws.Take(2).Sum() == 20) return true;

            return false;
        }
    }
}