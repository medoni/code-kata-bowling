using System.Collections;

namespace BowlingCodeKata.BowlingGame;

public class FramesList : IReadOnlyList<BaseFrame>
{
    private readonly List<BaseFrame> _frames;

    public FramesList()
    {
        _frames = new List<BaseFrame>();
    }

    internal FramesList(IEnumerable<BaseFrame> frames)
    {
        _frames = new List<BaseFrame>(frames);
    }

    #region IReadOnlyList<Frame> - Member

    public BaseFrame this[int index] => _frames[index];

    public int Count => _frames.Count;

    public IEnumerator<BaseFrame> GetEnumerator()
    => _frames.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => _frames.GetEnumerator();

    #endregion

    public void Add(BaseFrame frame)
    {
        _frames.Add(frame);
    }
}
