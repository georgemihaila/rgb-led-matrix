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

namespace LEDMatrix.Runner
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "10.10.0.241", UserName = "ledpanel", Password = "ledpanel" };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueBind(Constants.DEFAULT_QUEUE_NAME, Constants.DEFAULT_EXCHANGE_NAME, string.Empty);

                //channel.QueueDeclare(LEDMatrix.Core.Constants.DEFAULT_EXCHANGE_NAME);

                var matrix =
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
                    HardwareMapping = "regular",
                    ScanMode = 1,
                    PixelMapperConfig = "U-mapper",
                    ShowRefreshRate = true
                });
#endif
                var canvas = matrix.GetCanvas();
                canvas.Clear();
                Console.WriteLine($"Initialized RGB LED matrix with size {canvas.Width}x{canvas.Height}");
                var animations = new ParallelAggregatedAnimation(true);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);

                    var builder = new AnimationBuilder(canvas);
                    for(int x = 0; x < 32; x++)
                    {
                        for (int y = 0; y < 32; y++)
                        {
                            animations.Add(builder.AddPixelTransition(new Pixel(x, y, Color.Random), 5000).Build());
                        }
                    }
                    animations.Play();
                    canvas.Clear();
                };
                Console.WriteLine("Listening for queue messages...");
                channel.BasicConsume(Constants.DEFAULT_QUEUE_NAME, true, consumer);
                while (true)
                {
                    canvas = matrix.SwapOnVsync(canvas);
                    canvas.Clear();
                    animations.Update();
                    canvas.SetPixel(canvas.Width - 1, canvas.Height - 1, Color.Red);
                }

            }
        }
    }
}