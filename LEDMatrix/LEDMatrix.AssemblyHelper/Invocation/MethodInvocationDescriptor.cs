using LEDMatrix.Core;
using LEDMatrix.Core.Vectors;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.AssemblyHelper.Invocation
{
    public class MethodInvocationDescriptor
    {
        public static MethodInvocationDescriptor FromInstance<T>(string methodName, T instance) => new()
        {
            MethodName = methodName,
            Parameters = instance?.GetType().GetProperties().Select(x => new ParameterDescriptor()
            {
                Type = x.GetValue(instance)?.GetType(),
                Value = x.GetValue(instance),
                Name = x.Name
            }).ToArray()
        };

        public static MethodInvocationDescriptor From(string methodName, params (string ParameterName, object Value)[] constructorParameters) => new()
        {
            MethodName = methodName,
            Parameters = constructorParameters.Select(x => new ParameterDescriptor()
            {
                Type = x.Value.GetType(),
                Value = x.Value,
                Name = x.ParameterName
            }).ToArray()
        };

        public string? MethodName { get; set; }
        public ParameterDescriptor[]? Parameters { get; set; }
        public void InvokeOn<T>(T instance)
        {
            var methods = instance?.GetType().GetMethods();
            if (methods != null)
            {
                if (methods.Any(x => x.Name == MethodName && x.GetParameters().Length == Parameters?.Length))
                {
                    var method = methods.First(x => x.Name == MethodName && x.GetParameters().Length == Parameters?.Length);
                    var parameters = method.GetParameters();
                    var methodParameters = new List<object>();
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
#pragma warning disable CS8629 // Nullable value type may be null.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            if ((bool)(Parameters?.Any(x => x.Name.ToUpper().Equals(parameter.Name.ToUpper()))))
                            {
                                var p = Parameters?.First(x => x.Name.ToUpper().Equals(parameter.Name.ToUpper()));
                                object? o = null;
                                if (p.Type != null)
                                {
                                    if (p.Type == typeof(Color))
                                    {
                                        o = JsonConvert.DeserializeObject<Color>(JsonConvert.SerializeObject(p.Value));
                                    }
                                    else if (p.Type == typeof(Vector2<int>))
                                    {
                                        o = JsonConvert.DeserializeObject<Vector2<int>>(JsonConvert.SerializeObject(p.Value));
                                    }
                                    else
                                    {
                                        o = Convert.ChangeType(p.Value, parameter.ParameterType);
                                    }
                                }
                                if (o != null)
                                    methodParameters.Add(o);
                            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8629 // Nullable value type may be null.
                        }
                    }
                    method.Invoke(instance, methodParameters.ToArray());
                }
            }
        }
    }
}
