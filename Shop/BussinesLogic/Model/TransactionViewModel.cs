using BussinesLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.DTO__BusinessModels_
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public ClientViewModel Client { get; set; }

        public DateTime Date { get; set; }

        public Single? Amount { get; set; }
    }
}
