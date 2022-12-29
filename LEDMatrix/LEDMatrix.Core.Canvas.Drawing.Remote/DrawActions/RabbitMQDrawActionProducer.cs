using LEDMatrix.AssemblyHelper.Invocation;

using Newtonsoft.Json;

using RabbitMQ.Client;

using System.Text;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions
{
    public class RabbitMQDrawActionProducer : RabbitMQConnectionBase, IDrawActionProducer
    {
        protected readonly string _queueName;
        protected readonly string _routingKey;

        public RabbitMQDrawActionProducer(string hostName, string username, string password, string exchangeName, string queueName, string routingKey) : base(hostName, username, password, exchangeName)
        {
            _queueName = queueName;
            _routingKey = routingKey;
        }

        public void SendActionToQueue(MethodInvocationDescriptor message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, exclusive: false, durable: true, autoDelete: false);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(_exchangeName, _routingKey, body: body, mandatory: true);
            }
        }
    }
}
