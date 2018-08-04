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
                if (Double.Parse(value) > 0 && Double.TryParse(value, out double result))
                {
                    _price = result;

                }
                else
                {
                    throw new Exception("Invalid price");

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
                if (!String.IsNullOrWhiteSpace(value) && !Double.TryParse(value, out double a))
                {
                    _name = value;
                }
                else
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
                if (!String.IsNullOrWhiteSpace(value) && !Double.TryParse(value, out double a))
                {
                    _color = value;
                }
                else
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
