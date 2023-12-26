using System.Collections;

namespace BowlingCodeKata.BowlingGame;

/// <summary>
/// Responsible for storing information about a list of frames
/// </summary>
public class FramesList : IReadOnlyList<BaseFrame>
{
    private readonly List<BaseFrame> _frames;

    /// <summary>
    /// Creates a new <see cref="FramesList"/>
    /// </summary>
    public FramesList()
    {
        _frames = new List<BaseFrame>();
    }

    internal FramesList(IEnumerable<BaseFrame> frames)
    {
        _frames = new List<BaseFrame>(frames);
    }

    #region IReadOnlyList<Frame> - Member

    /// <inheritdoc/>
    public BaseFrame this[int index] => _frames[index];

    /// <inheritdoc/>
    public int Count => _frames.Count;

    /// <inheritdoc/>
    public IEnumerator<BaseFrame> GetEnumerator()
    => _frames.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => _frames.GetEnumerator();

    #endregion

    /// <summary>
    /// Adds a new frame
    /// </summary>
    public void Add(BaseFrame frame)
    {
        _frames.Add(frame);
    }
}
