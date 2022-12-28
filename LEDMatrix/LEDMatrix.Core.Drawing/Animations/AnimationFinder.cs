using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public class AnimationFinder
    {
        private readonly Assembly _assembly;

        public AnimationFinder(string path)
        {
            _assembly = Assembly.LoadFrom(path);
        }

        public IEnumerable<Type> FindAllConcreteAnimations()
        {
            var types = _assembly.GetTypes();
            foreach(var type in types)
            {
                if (typeof(IAnimation).IsAssignableFrom(type) && !(type.IsAbstract || type.IsInterface))
                    yield return type;
            }
        }
    }
}
