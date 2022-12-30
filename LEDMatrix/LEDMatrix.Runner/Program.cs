using LEDMatrix.Core.Matrix;

using System.Text;
using LEDMatrix.Core.Canvas.Drawing.Animations.Collections;
using Newtonsoft.Json;
using static LEDMatrix.Core.Constants.RMQ;
using LEDMatrix.AssemblyHelper.Invocation;
using LEDMatrix.Core.Canvas.Drawing.Remote.Subscription;
using LEDMatrix.Core.Logging;
#if RELEASE
using LEDMatrix.Core.Canvas.Drawing.Options;
#endif

ILogger logger = new ConsoleLogger();
var subscriber = new QueueSubscriber(HOSTNAME, USERNAME, PASSWORD, DEFAULT_EXCHANGE_NAME);
var directInvocationSubscription = subscriber.CreateQueueSubscription(DIRECT_INVOCATION_QUEUE_NAME, ROUTING_KEY);
directInvocationSubscription.CallbackException += (chann, args) =>
{
    logger.Error(args.Exception.ToString());
};
var matrix =
#if DEBUG
new MockRGBLEDMatrix();
logger.Debug("Initialized Mock RGB LED matrix");
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
logger.Debug($"Initialized RGB LED matrix with size {canvas.Width}x{canvas.Height}");
var animations = new ParallelAggregatedAnimation(true);
directInvocationSubscription.MessageReceived += (model, eventArgs) =>
{
    try
    {
        var body = eventArgs.Body.ToArray();
        var str = Encoding.UTF8.GetString(body);
        logger.Info(str);
        var message = JsonConvert.DeserializeObject<MethodInvocationDescriptor>(str);
        message.InvokeOn(canvas);
    }
    catch (Exception e)
    {
        logger.Error(e);
    }
    finally
    {
        directInvocationSubscription.Channel.BasicAck(eventArgs.DeliveryTag, false);
    }
};
while (true)
{
    canvas = matrix.SwapOnVsync(canvas);
    animations.Update(canvas);
    matrix.Refresh(canvas);
}