using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();
            Type type = Type.GetType("Stealer." + className);
            MethodInfo[] nonPublicMethods = type.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return result.ToString().Trim();
        }
    }
}
