namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public interface IAnimation
    {
        public double DurationMilliseconds { get; }
        public void Update(IRGBLEDCanvas canvas);
        public bool Completed { get; }
        public event EventHandler<AnimationRunStatistics> OnAnimationCompleted;
        public void Play();
        public string? ToString();
    }
}
