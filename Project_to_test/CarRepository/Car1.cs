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

        internal void CalculateDiscount(string sizeOfDiscount)
        {
            if (Double.Parse(sizeOfDiscount) > 0 && (Double.TryParse(sizeOfDiscount, out double result)))
            {
                SetDiscount(result);
            }
            else
            {
                throw new Exception("Invalid entry");
            }
        }

        public void accessToDiscount (string size)
        {
            CalculateDiscount(size);
        }
    }
}
