using LEDMatrix.Core.Logging;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.Subscription
{
    public class QueueSubscriber : RabbitMQConnectionBase
    {
        private readonly ILogger? _logger;
        public QueueSubscriber(string hostName, string username, string password, string exchangeName, ILogger? logger = null) : base(hostName, username, password, exchangeName)
        {
            _logger = logger;
        }

        public QueueSubscription CreateQueueSubscription(string queueName, string routingKey)
        {
            var channel = _connection.CreateModel();
            channel.QueueBind(queueName, _exchangeName, routingKey);
            var consumer = new EventingBasicConsumer(channel);
            QueueSubscription result = new(consumer, channel);
            var tag = channel.BasicConsume(queueName, false, consumer);
            channel.DefaultConsumer = consumer;
            _logger?.Debug($"Listening for queue messages on exchange {_exchangeName}, queue {queueName}, key {routingKey} with tag {tag}...");
            return result;
        }
    }
}
