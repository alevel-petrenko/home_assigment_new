using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    class Generic
    {
        public bool AreSame<T> (T operand1, T operand2) where T : class 
            // class - ref type, struct - value type, 
            // new() - instances of classes, Person конкретный персон и его наследники
        {            
            return operand1.Equals(operand2);
        }

        public void ShowInfo<T>(T operand)
        {
            if (operand!=null)
            {
                foreach (var prop in operand.GetType().GetProperties())
                {
                    Console.WriteLine($"PropertyName : {prop.Name}," +
                        $"propertyType : {prop.PropertyType.Name}," +
                        $"Property Value : {prop.GetValue(operand)}");
                    if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsEnum
                        || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                    {
                        continue;
                    }
                    else
                    {
                        var propValue = prop.GetValue(operand, null);
                        ShowInfo(propValue);
                    }
                }
            } 
        }
    }
}
