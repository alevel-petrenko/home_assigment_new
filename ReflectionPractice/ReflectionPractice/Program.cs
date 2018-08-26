using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    class Program
    {
        /// рекурсивно зайти в персон и достучаться до CardName, CardNumber и вывести на экран
        /// выполнено в методе ShowInfo<T>

        static void Main(string[] args)
        {
            Generic gen = new Generic();
            Console.WriteLine(gen.AreSame<string>("Olya", "Sasha"));


            Calc calc = new Calc();
            Type calcType = calc.GetType();

            MethodInfo method = calcType.GetMethod("Add");
            var param = new object[] { 6, 7 }; 
            // create params that will be passed to method
            // массив object обязательно

            Console.WriteLine(method?.Invoke(calc, param));
            //? проверка на null

            Person p = new Person()
            {
                Age = 25,
                CardInfo = new BankCardInfo()
                {
                    CardName = "Name",
                    CardNumber = "2233 5566 4488 7788"
                },
                Email = "dfdjfo@gmail",
                FirstName = "Kolya",
                LastName = "Bomzh"
            };

            foreach (var prop in p.GetType().GetProperties())
            {
                Console.WriteLine($"PropertyName : {prop.Name}," +
                    $"propertyType : {prop.PropertyType.Name}," +
                    $"Property Value : {prop.GetValue(p)}");
            }
        }
    }
}
