using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepository;

namespace Autos_discount
{
    class Program
    {
        //соглашение - указывать значение через this/_name для приватных полей/методов
        
        static void Main(string[] args)
        {
            string percent;

            Car[] carPark = new Car [3];

            Console.WriteLine("Enter car name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter car color");
            string color = Console.ReadLine();
            Console.WriteLine("Enter car price");
            string price = Console.ReadLine();

            carPark[0] = new Car(name, color, price);
            carPark[1] = new Car("BMW", "black", "15000");
            carPark[2] = new Car("Volvo", "red", "12000");

            for (int i = 0; i < carPark.Length; i++)
            {
                Console.WriteLine("Enter your discount in percent for {0} car", i+1);
                percent = Console.ReadLine();
                carPark[i].CalculateDiscount(percent);
                Console.WriteLine("Initiall price for {0} is {1}. Price with discount is {2} \n", carPark[i].Name, carPark[i].Price, carPark[i].GetDiscount());
            }
        }
    }
}