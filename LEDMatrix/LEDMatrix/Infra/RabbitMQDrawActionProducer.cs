using Newtonsoft.Json;

using RabbitMQ.Client;
using System.Text;

using static LEDMatrix.Core.Constants;

namespace LEDMatrix.Server.Infra
{
    public class RabbitMQDrawActionProducer : IDrawActionProducer
    {
        public void SendActionToQueue<T>(T message) where T : IDrawAction
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: DEFAULT_QUEUE_NAME, exclusive: false, durable: true, autoDelete: false);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(DEFAULT_EXCHANGE_NAME, string.Empty, body: body, mandatory: true);
            }
        }
    }
}
