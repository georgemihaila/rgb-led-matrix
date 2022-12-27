using LEDMatrix.Core;
using LEDMatrix.Core.Drawing.Actions.Pixels;
using LEDMatrix.Server.Infra;

using Microsoft.AspNetCore.Mvc;

namespace LEDMatrix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixelController : ControllerBase
    {
        private readonly IRGBLEDCanvas _canvas;

        public PixelController(IRGBLEDCanvas canvas)
        {
            _canvas = canvas;
        }

        [HttpPost]
        public IActionResult SetPixel([FromBody] Pixel pixel)
        {
            _canvas.SetPixel(pixel);
            return Ok();
        }
    }
}