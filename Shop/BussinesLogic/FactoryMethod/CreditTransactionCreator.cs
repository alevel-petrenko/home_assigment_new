using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;

namespace BussinesLogic.FactoryMethod
{
    public class CreditTransactionCreator : TransactionCreator
    {
        protected override Transactions CreateTransaction()
        {
            var transaction = new CreditTransactions();

            return transaction;
        }


    }
}
