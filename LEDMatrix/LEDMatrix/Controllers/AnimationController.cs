using LEDMatrix.Core;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Server.Infra;

using Microsoft.AspNetCore.Mvc;

namespace LEDMatrix.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnimationController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<string> ListAnimations()
        {
            yield return "";
        }
    }
}