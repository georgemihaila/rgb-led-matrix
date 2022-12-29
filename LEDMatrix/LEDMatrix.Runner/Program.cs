using LEDMatrix.Core.Matrix;

using System.Text;
using LEDMatrix.Core.Canvas.Drawing.Animations.Collections;
using Newtonsoft.Json;
using static LEDMatrix.Core.Constants.RMQ;
using LEDMatrix.AssemblyHelper.Invocation;
using LEDMatrix.Core.Canvas.Drawing.Remote.Subscription;
#if RELEASE
using LEDMatrix.Core.Canvas.Drawing.Options;
#endif

var subscriber = new QueueSubscriber(HOSTNAME, USERNAME, PASSWORD, DEFAULT_EXCHANGE_NAME);
var directInvocationSubscription = subscriber.CreateQueueSubscription(DIRECT_INVOCATION_QUEUE_NAME, ROUTING_KEY);
directInvocationSubscription.CallbackException += (chann, args) =>
{
    Console.WriteLine(JsonConvert.SerializeObject(args));
};
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
directInvocationSubscription.MessageReceived += (model, eventArgs) =>
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
        directInvocationSubscription.Channel.BasicAck(eventArgs.DeliveryTag, false);
    }
};
while (true)
{
    canvas = matrix.SwapOnVsync(canvas);
    canvas.Clear();
    animations.Update(canvas);
    //matrix.Refresh(canvas);
}