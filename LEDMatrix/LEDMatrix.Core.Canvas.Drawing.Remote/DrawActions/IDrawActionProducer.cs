using LEDMatrix.AssemblyHelper.Invocation;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions
{
    public interface IDrawActionProducer
    {
        public void SendActionToQueue(MethodInvocationDescriptor message);
    }
}
