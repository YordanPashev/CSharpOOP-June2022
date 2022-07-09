using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                    .GetType()
                    .GetProperties()
                    .Where(p => p.GetCustomAttributes(typeof(MyValidationAttribute), true).Any())
                    .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                MyValidationAttribute attribute = property.GetCustomAttribute<MyValidationAttribute>();

                if (!attribute.IsValid(value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
