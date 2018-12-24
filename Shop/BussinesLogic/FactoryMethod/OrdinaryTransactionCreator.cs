using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;

namespace BussinesLogic.FactoryMethod
{
    public class OrdinaryTransactionCreator : TransactionCreator
    {
        protected override Transactions CreateTransaction()
        {
            var transaction = new OrdinaryTransction();

            return transaction;
        }
    }
}
