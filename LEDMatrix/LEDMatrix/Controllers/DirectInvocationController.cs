using LEDMatrix.Core;
using LEDMatrix.Core.Canvas.Drawing.Actions.Pixels;
using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Vectors;
using LEDMatrix.Server.Infra;

using Microsoft.AspNetCore.Mvc;

using System.Reflection;

namespace LEDMatrix.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DirectInvocationController : ControllerBase
    {
        private readonly IRGBLEDCanvas _canvas;

        public DirectInvocationController(IRGBLEDCanvas canvas)
        {
            _canvas = canvas;
        }

        public int Width => _canvas.Width;

        public int Height => _canvas.Height;
        [HttpGet]
        public Vector2<int> GetCanvasSize()
        {
            return new(Width, Height);
        }
        [HttpPost]
        public void AddColorToPixel(int x, int y, Color color)
        {
            _canvas.AddColorToPixel(x, y, color);
        }
        [HttpPost]
        public void Clear()
        {
            _canvas.Clear();
        }
        [HttpPost]
        public void DrawCircle(int x0, int y0, int radius, Color color)
        {
            _canvas.DrawCircle(x0, y0, radius, color);
        }
        [HttpPost]
        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            _canvas.DrawLine(x0, y0, x1, y1, color);
        }
        [HttpPost]
        public int DrawText(string fontName, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            if (string.IsNullOrWhiteSpace(fontName))
                throw new ArgumentNullException(nameof(fontName));
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrWhiteSpace(directory))
                throw new Exception("Directory null");

            return _canvas.DrawText(new(Path.Combine(directory, fontName)), x, y, color, text, spacing, vertical);
        }
        [HttpPost]
        public void Fill(Color color)
        {
            _canvas.Fill(color);
        }
        [HttpGet]
        public Pixel GetPixel(int x, int y)
        {
            return _canvas.GetPixel(x, y);
        }

        [HttpPost]
        public IActionResult SetPixel([FromBody] Pixel pixel)
        {
            _canvas.SetPixel(pixel);
            return Ok();
        }

        [HttpPost]
        public IActionResult SetPixels([FromBody] Pixel[] pixels)
        {
            _canvas.SetPixels(pixels);
            return Ok();
        }
    }
}