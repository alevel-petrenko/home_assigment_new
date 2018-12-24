using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.DTO__BusinessModels_
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public ClientDTO Client { get; set; }

        public DateTime Date { get; set; }

        public double? Amount { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
