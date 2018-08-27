using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void ShowAllInfo<T>(T operand)
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
                        ShowAllInfo(propValue);
                    }
                }
            } 
        }

        public List<string> WriteInfoAboutPrimitive<T>(T instance)
        {
            List<string> instanceProperties = new List<string>();
            if (instance != null)
            {
                foreach (var prop in instance.GetType().GetProperties())
                {
                    instanceProperties.Add(($"*{prop.Name}* = *{prop.GetValue(instance)}*\r\n"));
                }
            }
            return instanceProperties;
        }

        public void TransformToText<T>(T instance)
        {
            //if (File.Exists(@"C:\Temp\file.txt"))
            foreach (var item in WriteInfoAboutPrimitive(instance))
            {
                File.AppendAllText(@"C:\Temp\file.txt", item);
            }
            Console.WriteLine("file.txt has been successfully rewrited");
        }
    }
}
