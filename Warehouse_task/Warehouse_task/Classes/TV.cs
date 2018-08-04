using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_task.Classes
{
    class TV : Goods
    {
        public override string Name { get; set; } = "Samsung";
        public override double Price { get; set; } = 1000;
        public override double SafetyTerm { get; set; } = 10;
    }
}