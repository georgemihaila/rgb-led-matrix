using LEDMatrix.Core;
using LEDMatrix.Core.Canvas.Drawing.Animations;
using LEDMatrix.Server.Infra;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDrawActionProducer, RabbitMQDrawActionProducer>();
builder.Services.AddSingleton<IRGBLEDCanvas, RMQVirtualRGBLEDCanvas>();
builder.Services.AddSingleton(new AnimationFinder(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LEDMatrix.Core.Canvas.Drawing.dll")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
