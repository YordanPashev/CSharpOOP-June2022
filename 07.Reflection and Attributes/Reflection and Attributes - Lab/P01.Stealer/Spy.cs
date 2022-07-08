using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classType, params string[] fieldsToDsplay)
        {
            StringBuilder result = new StringBuilder();
            Type nameOfTheClass = Type.GetType(classType);
            var instance = Activator.CreateInstance(nameOfTheClass, new object[] { });
            FieldInfo[] fields = instance.GetType().GetFields((BindingFlags)60);

            result.AppendLine($"Class under investigation: {nameOfTheClass}");

            foreach (FieldInfo field in fields.Where(f => fieldsToDsplay.Contains(f.Name)))
            {       
                    result.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return result.ToString().Trim();
        }
    }
}
