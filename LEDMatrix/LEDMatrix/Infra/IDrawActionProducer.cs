using LEDMatrix.Core.Invocation;

namespace LEDMatrix.Server.Infra
{
    public interface IDrawActionProducer
    {
        public void SendActionToQueue(MethodInvocationDescriptor message);
    }
}
