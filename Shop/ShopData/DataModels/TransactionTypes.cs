using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.DataModels
{
    public class OrdinaryTransction : Transactions
    {
        public string PaymentSystemId { get; set; }
    }

    public class CreditTransactions : Transactions
    {
        public string BillNumber { get; set; }
        public double OverDraft { get; set; }
        public string ManagerNotes { get; set; }
        public string CommitmentDate { get; set; }
    }
}
