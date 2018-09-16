using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Phone
    {
        public PhoneTypes Type { get; set; }  //1 home, 2 mobile, 3 work

        public string Number { get; set; }
    }

    public enum PhoneTypes
    {
        Home=1,
        Mobile,
        Work
    }
}
