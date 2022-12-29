using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.Subscription
{
    public class QueueSubscriber : RabbitMQConnectionBase
    {
        public QueueSubscriber(string hostName, string username, string password, string exchangeName) : base(hostName, username, password, exchangeName)
        {
        }

        public QueueSubscription CreateQueueSubscription(string queueName, string routingKey)
        {
            var channel = _connection.CreateModel();
            channel.QueueBind(queueName, _exchangeName, routingKey);
            var consumer = new EventingBasicConsumer(channel);
            QueueSubscription result = new(consumer, channel);
            Console.WriteLine(channel.BasicConsume(queueName, false, consumer));
            channel.DefaultConsumer = consumer;
            Console.WriteLine($"Listening for queue messages on exchange {_exchangeName}, queue {queueName}, key {routingKey}...");
            return result;
        }
    }
}
