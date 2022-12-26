using LEDMatrix.Core;

namespace LEDMatrix.Server.Infra
{
    public class SetPixelAction : IDrawAction
    {
        public Pixel FinalState { get; private set; }
        public string Name { get; set; }

        public SetPixelAction(Pixel finalState)
        {
            FinalState = finalState;
        }
    }
}
