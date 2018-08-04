using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_task.Classes
{
    abstract class Goods
    {
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }
        public abstract double SafetyTerm { get; set; }

        public DateTime CalculateEndDate(DateTime DateOfIncome)
        {
            return DateOfIncome.AddDays(SafetyTerm);
        }
    }
}