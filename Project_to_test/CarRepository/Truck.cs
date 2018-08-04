using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    class Truck: Car
    {
        public double Capacity { get; set; }

        public double Mileage { get; set; }

        public string Insurance { get; set; }

        public Truck(string name, string color, string price, double capacity, double mileage, string insurance) : base(name, color, price)
        { 
            Capacity = capacity;
            Mileage = mileage;
            Insurance = insurance;
        }

        public new void accessToDiscount (string empty)
        {
            double price = Double.Parse(Price);            
            price *= 0.7;
        }
    }
}
