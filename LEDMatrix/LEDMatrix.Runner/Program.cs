using LEDMatrix.Core;
using LEDMatrix.Core.Matrix;
using LEDMatrix.Core.Options;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;
using System;
using Constants = LEDMatrix.Core.Constants;
using LEDMatrix.Core.Drawing.Animations;
using LEDMatrix.Core.Drawing.Actions.Pixels;

var factory = new ConnectionFactory { HostName = "10.10.0.241", UserName = "ledpanel", Password = "ledpanel" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueBind(Constants.DEFAULT_QUEUE_NAME, Constants.DEFAULT_EXCHANGE_NAME, string.Empty);

//channel.QueueDeclare(LEDMatrix.Core.Constants.DEFAULT_EXCHANGE_NAME);

IRGBLEDMatrix matrix =
#if DEBUG
    new MockRGBLEDMatrix();
Console.WriteLine("Initialized Mock RGB LED matrix");
#else
new RGBLedMatrix(new RGBLedMatrixOptions()
{
    Brightness = 10,
    GpioSlowdown = 2,
    Rows = 64,
    Cols = 64,
    ChainLength = 4
});
Console.WriteLine("Initialized RGB LED matrix");
#endif
var canvas = matrix.CreateOffscreenCanvas();
List<IAnimation> animations = new();
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);

    var builder = new AnimationBuilder(canvas, 1000);
    var animation = builder.AddPixelTransition(new Pixel(0, 0, Color.Red)).Build();
    animations.Add(animation);
    animation.Play();
    Console.WriteLine($"Playing {eventArgs.Body}");
};
Console.WriteLine("Listening for queue messages...");
channel.BasicConsume(Constants.DEFAULT_QUEUE_NAME, true, consumer);
while (true)
{
    canvas = matrix.SwapOnVsync(canvas);
    foreach(var notCompleted in animations.Where(x => !x.Completed).ToList())
    {
        notCompleted.Tick();
    }
    foreach (var completed in animations.Where(x => x.Completed).ToList())
    {
        animations.Remove(completed);
    }
}