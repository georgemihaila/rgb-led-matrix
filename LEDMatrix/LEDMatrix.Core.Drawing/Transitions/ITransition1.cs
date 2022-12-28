namespace LEDMatrix.Core.Canvas.Drawing.Transitions
{
    /// <summary>
    /// Represents a transition between two values in RGB space
    /// </summary>
    public interface ITransition1 : IDrawAction
    {
        public Pixel From { get; }
    }
}
