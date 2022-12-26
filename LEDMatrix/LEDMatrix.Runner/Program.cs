using LEDMatrix.Core;
using LEDMatrix.Core.Matrix;
using LEDMatrix.Core.Options;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(LEDMatrix.Core.Constants.DEFAULT_EXCHANGE_NAME);

IRGBLEDMatrix matrix = new RGBLedMatrix(new RGBLedMatrixOptions()
{
    Brightness = 10,
    GpioSlowdown = 2,
    Rows = 64,
    Cols = 64,
    ChainLength = 4
});

var canvas = matrix.CreateOffscreenCanvas();

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine(message);
};

while (true)
{
    canvas = matrix.SwapOnVsync(canvas);
}