using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.Subscription
{
    public class QueueSubscription
    {
        private readonly EventingBasicConsumer _consumer;

        public event EventHandler<BasicDeliverEventArgs>? MessageReceived;
        public event EventHandler<CallbackExceptionEventArgs>? CallbackException;
        public IModel Channel { get; private set; }
        public QueueSubscription(EventingBasicConsumer consumer, IModel channel)
        {
            _consumer = consumer;
            Channel = channel;

            _consumer.Received += (model, eventArgs) => MessageReceived?.Invoke(model, eventArgs);
            Channel.CallbackException += (chann, args) => CallbackException?.Invoke(chann, args);
        }
    }
}
