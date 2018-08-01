using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public partial class Car
    {
        //using partial classes for dividing fields and methods
        private void SetDiscount(double discount)
        {
            _priceWithDiscount = _price * (1 - (discount / 100));
        }

        public double GetDiscount()
        {
            return _priceWithDiscount;
        }

        public virtual void CalculateDiscount(string sizeOfDiscount)
        {
            //как можно использовать метод internal если CarRepository это другая сборка?
            if (Double.Parse(sizeOfDiscount) <= 0)
            {
                throw new Exception("Invalid discount");
            }
            else if (Double.TryParse(sizeOfDiscount, out double result))
            {
                SetDiscount(result);
            }
            else if (!Double.TryParse(sizeOfDiscount, out double notDouble))
            {
                throw new Exception("Invalid entry");
            }
        }
    }
}
