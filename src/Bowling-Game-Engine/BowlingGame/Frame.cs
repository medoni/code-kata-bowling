namespace BowlingCodeKata.BowlingGame;

public abstract class BaseFrame
{
    private readonly List<SingleThrow> _throws;
    public IReadOnlyList<SingleThrow> Throws => _throws;

    public BaseFrame()
    {
        _throws = new List<SingleThrow>();
    }

    public abstract bool CanThrow { get; }
    public abstract bool ThrowFinished { get; }
    public virtual bool IsLastFrame { get; }

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
        _throws.Add(new SingleThrow(count));
    }
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
            if (Throws.Last().Count < 10) return false;

            return true;
        }
    }
}

public class LastFrame : BaseFrame
{
    // todo unit tests
    public override bool IsLastFrame => true;
    public override bool CanThrow => !ThrowFinished;
    public override bool ThrowFinished
    {
        get
        {
            if (Throws.Count == 0) return false;
            if (Throws.Count == 1) return false;
            if (Throws.Count == 3) return true;

            if (Throws.Take(2).Sum(x => x.Count) < 10) return true;

            return false;
        }
    }
}

public record SingleThrow(
    int Count
);