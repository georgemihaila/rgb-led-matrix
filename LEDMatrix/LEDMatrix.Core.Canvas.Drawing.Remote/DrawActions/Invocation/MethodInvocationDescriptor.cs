using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions.Invocation
{
    public class MethodInvocationDescriptor
    {
        public static MethodInvocationDescriptor FromInstance<T>(string methodName, T instance) => new MethodInvocationDescriptor()
        {
            MethodName = methodName,
            ConstructorParameters = instance?.GetType().GetProperties().Select(x => new TypeDescriptor()
            {
                Type = x.GetValue(instance)?.GetType(),
                Value = x.GetValue(instance)
            }).ToArray()
        };

        public static MethodInvocationDescriptor From(string methodName, params object[] constructorParameters) => new MethodInvocationDescriptor()
        {
            MethodName = methodName,
            ConstructorParameters = constructorParameters.Select(x => new TypeDescriptor()
            {
                Type = x.GetType(),
                Value = x
            }).ToArray()
        };

        public string? MethodName { get; set; }
        public TypeDescriptor[]? ConstructorParameters { get; set; }
    }
}
