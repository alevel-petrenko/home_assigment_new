using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BussinessLogic.Category;

namespace BussinessLogic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Category { get; set; }
        public double Price { get; set; }
        public int StartHappyHours { get; set; }
        public int EndHappyHours { get; set; }
        
        public double FinalPrice ()
        {
            return DateTime.Now.Hour >= StartHappyHours && DateTime.Now.Hour <= EndHappyHours ? Price * 0.8 : Price;
        }
    }
}
