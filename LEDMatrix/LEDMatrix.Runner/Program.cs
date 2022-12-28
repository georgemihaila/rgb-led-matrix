using LEDMatrix.Core;
using LEDMatrix.Core.Matrix;
using LEDMatrix.Core.Canvas.Drawing.Options;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;
using System;
using Constants = LEDMatrix.Core.Constants;
using LEDMatrix.Core.Canvas.Drawing.Animations;
using LEDMatrix.Core.Canvas.Drawing.Actions.Pixels;
using LEDMatrix.Core.Canvas.Drawing.Animations.Collections;

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
    ChainLength = 4,
    HardwareMapping = "default",
    ScanMode = 1
});
#endif
var canvas = matrix.CreateOffscreenCanvas();
canvas.Clear();
Console.WriteLine($"Initialized RGB LED matrix with size {canvas.Width}x{canvas.Height}");
ParallelAggregatedAnimation animations = new(true);
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);

    var builder = new AnimationBuilder(canvas);
    animations.Add(builder.AddPixelTransition(new Pixel(0, 0, Color.Red), 1000).Build());
    animations.Add(builder.AddPixelTransition(new Pixel(31, 31, Color.Red), 5000).Build());
    animations.Play();
    canvas.Clear();
};
Console.WriteLine("Listening for queue messages...");
channel.BasicConsume(Constants.DEFAULT_QUEUE_NAME, true, consumer);
while (true)
{
    canvas = matrix.SwapOnVsync(canvas);
    animations.Update();
    canvas.SetPixel(31, 0, Color.Red);
}