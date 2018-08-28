using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReflectionPractice
{
    static class Generic
    {
        const string path = @"C:\Temp\file.txt";

        /// <summary>
        /// Compare two operands on equality
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <returns></returns>
        static public bool AreSame<T> (T operand1, T operand2) where T : class 
            // class - ref type, struct - value type, new() - instances of classes, Person конкретный персон и его наследники
        {            
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Show all Properties by Reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operand"></param>
        static public void ShowAllInfo<T>(T operand)
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

        /// <summary>
        /// Collect all properties from instance and add them to StringBuilder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        static public string WriteInfoAboutPrimitive<T>(T instance)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (instance != null)
            {
                stringBuilder.Append('[');
                foreach (var prop in instance.GetType().GetProperties())
                {
                    stringBuilder.AppendLine($"{prop.PropertyType} *{prop.Name}* = *{prop.GetValue(instance)}*");
                }
                stringBuilder.AppendLine("]");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Transforms collection with instance members to text file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        static public void TransformToText<T>(T instance)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteAsync(WriteInfoAboutPrimitive(instance));
            Console.WriteLine("file.txt has been successfully rewrited");
            writer.Close();
        }
    }
}
