namespace LEDMatrix.Core.Drawing.Animations
{
    public interface IAnimation
    {
        public double DurationMilliseconds { get; }
        public void Tick();
        public bool Completed { get; }
        public void Play();
    }
}
