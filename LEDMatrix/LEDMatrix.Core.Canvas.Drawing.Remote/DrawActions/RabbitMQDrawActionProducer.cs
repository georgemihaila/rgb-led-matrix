using LEDMatrix.AssemblyHelper.Invocation;

using Newtonsoft.Json;

using RabbitMQ.Client;

using System.Text;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions
{
    public class RabbitMQDrawActionProducer : IDrawActionProducer
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _exchangeName;
        private readonly string _queueName;
        private readonly string _routingKey;

        public RabbitMQDrawActionProducer(string hostName, string username, string password, string exchangeName, string queueName, string routingKey)
        {
            _hostName = hostName;
            _username = username;
            _password = password;
            _exchangeName = exchangeName;
            _queueName = queueName;
            _routingKey = routingKey;
        }

        public void SendActionToQueue(MethodInvocationDescriptor message)
        {
            Console.WriteLine($"Initializing connection on exchange {_exchangeName}, queue {_queueName}, key {_routingKey}...");
            var factory = new ConnectionFactory { HostName = _hostName, UserName = _username, Password = _password };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, exclusive: false, durable: true, autoDelete: false);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(_exchangeName, _routingKey, body: body, mandatory: true);
            }
        }
    }
}
