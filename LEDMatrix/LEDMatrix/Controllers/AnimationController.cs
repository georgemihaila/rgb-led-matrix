using LEDMatrix.Core;
using LEDMatrix.Core.Canvas.Drawing.Animations;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Server.Infra;

using Microsoft.AspNetCore.Mvc;

namespace LEDMatrix.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnimationController : ControllerBase
    {
        private readonly AnimationFinder _animationFinder;

        public AnimationController(AnimationFinder animationFinder)
        {
            _animationFinder = animationFinder;
        }

        [HttpPost]
        public IEnumerable<string> ListAnimations()
        {
            return _animationFinder.FindAllConcreteAnimations().Select(x => x.Name);
        }
    }
}