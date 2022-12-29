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
using Newtonsoft.Json;
using static LEDMatrix.Core.Constants.RMQ;
using LEDMatrix.AssemblyHelper.Invocation;
using System.Diagnostics;

namespace LEDMatrix.Runner
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = HOSTNAME, UserName = USERNAME, Password = PASSWORD };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueBind(DEFAULT_QUEUE_NAME, DEFAULT_EXCHANGE_NAME, ROUTING_KEY);

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
                    //ShowRefreshRate = true
                });
#endif
                var canvas = matrix.GetCanvas();
                canvas.Clear();
                Console.WriteLine($"Initialized RGB LED matrix with size {canvas.Width}x{canvas.Height}");
                var animations = new ParallelAggregatedAnimation(true);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    try
                    {
                        var body = eventArgs.Body.ToArray();
                        var str = Encoding.UTF8.GetString(body);
                        Console.WriteLine(str);
                        var message = JsonConvert.DeserializeObject<MethodInvocationDescriptor>(str);
                        message.InvokeOn(canvas);
                        /*
                        var builder = new AnimationBuilder(canvas);
                        //Add animations
                        animations.Play();
                        canvas.Clear();*/
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        channel.BasicAck(eventArgs.DeliveryTag, false);
                    }
                };
                channel.BasicConsume(DEFAULT_QUEUE_NAME, false, consumer);
                Console.WriteLine($"Listening for queue messages on exchange {DEFAULT_EXCHANGE_NAME}, queue {DEFAULT_QUEUE_NAME}, key {ROUTING_KEY}...");
                
                while (true)
                {
                    canvas = matrix.SwapOnVsync(canvas);
                    canvas.Clear();
                    animations.Update(canvas);
                    //matrix.Refresh(canvas);
                }

            }
        }
    }
}