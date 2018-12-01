using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.DTO__BusinessModels_
{
    public class TransactionsDTO
    {
        public int Id { get; set; }

        public ClientDTO Client { get; set; }

        public DateTime Date { get; set; }

        public float Amount { get; set; }
    }
}
