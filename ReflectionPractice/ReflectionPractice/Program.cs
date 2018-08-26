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
            //Console.WriteLine(gen.AreSame<string>("Olya", "Sasha"));

            Calc calc = new Calc();
            Type calcType = calc.GetType();

            MethodInfo method = calcType.GetMethod("Add");
            var param = new object[] { 6, 7 }; 
            // create params that will be passed to method
            // массив object обязательно
            //Console.WriteLine(method?.Invoke(calc, param));
            //? проверка на null

            // option to call for the type (typeof)
            Type type = typeof(Person);
            //foreach (var item in type.GetMembers() )
            //{
            //    Console.WriteLine(item);
            //}

            Person p1 = new Person()
            {
                Age = 25,
                FirstName = "Kolya",
                LastName = "Turgenev",
                CardInfo = new BankCardInfo()
                {
                    CardName = "Mono",
                    CardNumber = "2233 5566 4488 7788",
                    Cvv = "987",
                    Pin = "0000"
                },
                Email = "dfdjfo@gmail.com",                
                Password = "password1"
            };

            Person p2 = new Person()
            {
                Age = 35,
                FirstName = "Tamara",
                LastName = "Lukashina",
                CardInfo = new BankCardInfo()
                {
                    CardName = "Oschad",
                    CardNumber = "1234 5566 5678 0000",
                    Cvv = "987",
                    Pin = "5555"
                },
                Email = "tamaraL@gmail.com",
                Password = "passEASY"
            };

            List<Person> persons = new List<Person> { p1, p2};
            foreach (var person in persons)
            {
                gen.TransformToText(person);
            }
        }
    }
}
