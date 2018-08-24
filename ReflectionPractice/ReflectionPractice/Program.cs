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
        ///рекурсивно зайти в персон и достучаться до CardName, CardNumber и вывести на экран

        static void Main(string[] args)
        {
            Generic gen = new Generic();
            Console.WriteLine(gen.AreSame<string>("Olya", "Sasha"));


            Calc calc = new Calc();
            Type calcType = calc.GetType();

            MethodInfo method = calcType.GetMethod("Add");
            var param = new object[] { 6, 7 }; //create params that will be passed to method
            //массив object обязательно

            Console.WriteLine(method?.Invoke(calc, param));
            //? проверка на налл

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

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public BankCardInfo CardInfo { get; set; }
        [SecureData] //action filter
        public string Password { get; set; }
    }

    public class BankCardInfo
    {
        [SecureData] //action filter
        public string Cvv { get; set; }
        public string Pin { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
    }

     public class SecureData : Attribute
    {

    }
}
