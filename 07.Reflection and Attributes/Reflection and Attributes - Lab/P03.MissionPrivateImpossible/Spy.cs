using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();
            Type type = Type.GetType("Stealer." + className);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            result.AppendLine($"All Private Methods of Class: {type.Name}");
            result.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (MethodInfo method in nonPublicMethods)
            {
                result.AppendLine($"{method.Name}");
            }

            return result.ToString().Trim();
        }
    }
}
