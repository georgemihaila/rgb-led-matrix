using LEDMatrix.Core;
using LEDMatrix.Server.Infra;

using Microsoft.AspNetCore.Mvc;

namespace LEDMatrix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PixelController : ControllerBase
    {
        private readonly IDrawActionProducer _drawActionProducer;

        public PixelController(IDrawActionProducer drawActionProducer)
        {
            _drawActionProducer = drawActionProducer;
        }

        [HttpPost]
        public IActionResult SetPixel([FromBody] Pixel pixel)
        {
            _drawActionProducer.SendActionToQueue(new SetPixelAction(pixel));
            return Ok();
        }
    }
}