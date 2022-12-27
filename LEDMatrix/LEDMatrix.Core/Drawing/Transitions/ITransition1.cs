namespace LEDMatrix.Core.Drawing.Transitions
{
    public interface ITransition1 : IDrawAction
    {
        public Pixel From { get; }
        public IRGBLEDCanvas Canvas { get; }
    }
}
