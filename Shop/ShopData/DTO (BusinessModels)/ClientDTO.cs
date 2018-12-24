using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.DTO__BusinessModels_
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public UserCategory UserCategory { get; set; }
    }
}
