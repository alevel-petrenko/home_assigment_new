using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public PhoneTypes Type { get; set; }

        public string Number { get; set; }
    }

    public enum PhoneTypes
    {
        Home=1,
        Mobile,
        Work
    }
}
