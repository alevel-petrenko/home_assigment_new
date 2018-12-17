using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public abstract class TransactionCreator
    {
        protected abstract Transactions CreateTransaction();
    }
}
