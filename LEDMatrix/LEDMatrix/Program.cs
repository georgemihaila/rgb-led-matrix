using LEDMatrix.Core;
using LEDMatrix.Core.Canvas.Drawing.Animations;
using LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions;
using LEDMatrix.Server.Infra;
using static LEDMatrix.Core.Constants.RMQ;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDrawActionProducer, RabbitMQDrawActionProducer>(x => new RabbitMQDrawActionProducer(HOSTNAME, USERNAME, PASSWORD, DEFAULT_EXCHANGE_NAME, DIRECT_INVOCATION_QUEUE_NAME, ROUTING_KEY));
builder.Services.AddSingleton<IRGBLEDCanvas, RMQVirtualRGBLEDCanvas>();
var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
if (!string.IsNullOrWhiteSpace(directory))
    builder.Services.AddSingleton(new AnimationFinder(Path.Combine(directory, "LEDMatrix.Core.Canvas.Drawing.dll")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
