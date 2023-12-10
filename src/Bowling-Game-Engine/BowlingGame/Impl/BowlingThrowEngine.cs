namespace BowlingCodeKata.BowlingGame.Impl;

public class BowlingThrowEngine : IBowlingThrowEngine
{
    private readonly FramesList _frames;

    internal BowlingThrowEngine(
        FramesList frames
    )
    {
        _frames = frames ?? throw new ArgumentNullException(nameof(frames));
    }

    public void Throw(int count)
    {
        ThrowExceptionWhenFinished();

        GetOrAddFrame().AddThrow(count);
    }

    private BaseFrame GetOrAddFrame()
    {
        var frame = _frames.LastOrDefault();
        if (frame is null) frame = CreateFrame();
        else if (frame.ThrowFinished && frame.IsLastFrame) throw BowlingException.CreateGameHasFinished();
        else if (frame.ThrowFinished) frame = CreateFrame();

        return frame;
    }

    private BaseFrame CreateFrame()
    {
        var frame = BaseFrame.Create(_frames.Count + 1);
        _frames.Add(frame);
        return frame;
    }

    internal bool CanThrow(int throwCount) => _frames.LastOrDefault()?.CanThrow ?? true;

    private void ThrowExceptionWhenFinished()
    {
        if (IsFinished) throw BowlingException.CreateGameHasFinished();
    }

    public bool IsFinished
    {
        get
        {
            var lastFrame = _frames.LastOrDefault();
            if (lastFrame is null) return false;

            return lastFrame.IsLastFrame;
        }
    }

    public bool ThrowFinished => _frames.LastOrDefault()?.ThrowFinished ?? false;
}
