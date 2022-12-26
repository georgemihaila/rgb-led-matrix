namespace LEDMatrix.Server.Infra
{
    public interface IDrawActionProducer
    {
        public void SendActionToQueue<T>(T message) where T: IDrawAction;
    }
}
