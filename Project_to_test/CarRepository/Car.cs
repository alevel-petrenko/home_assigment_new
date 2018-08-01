using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public partial class Car
    {
        private double _price;
        private string _name;
        private string _color;
        private double _priceWithDiscount;

        public Car(string name, string color, string price)
        {
            Price = price;
            Color = color;
            Name = name;
        }

        public string Price
        {
            set
            { 
                //положительное значение и не строка
                if (Double.Parse(value) <= 0)
                {
                    throw new Exception("Invalid price");
                }
                else if (Double.TryParse(value, out double result))
                {
                    _price = result;
                }
                else if (!Double.TryParse(value, out double notDouble))
                {
                    throw new Exception("It's not a number!");
                }
            }
            get
            {
                return _price.ToString();
            }
        }

        public string Name
        {
            set
            {
                //не число и не пустая строка
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else if (Double.TryParse(value, out double a))
                {
                    throw new Exception("it's not a string!");
                }
            }
            get
            {
                return _name;
            }
        }

        public string Color
        {
            set
            {
                //не число и не пустая строка
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _color = value;
                }
                else if (Double.TryParse(value, out double a))
                {
                    throw new Exception("it's not a string!");
                }
                
            }
            get
            {
                return _color;
            }
        }
    }
}
