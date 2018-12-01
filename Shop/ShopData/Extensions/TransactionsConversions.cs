using ShopData.DataModels;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Extensions
{
    public static class TransactionsConversions
    {
        public static TransactionsDTO to_DTOModel(this Transactions transactions)
        {
            if (transactions == null)
            {
                return null;
            }

            return new TransactionsDTO
            {
                Id = transactions.Id,
                Date = transactions.Date.Value,
                Amount = transactions.Amount.Value,
                //ClientId = transactions.ClientId.

            };
        }

        public static Transactions to_SQLModel(this TransactionsDTO transactionsDTO)
        {
            if (transactionsDTO == null)
            {
                return null;
            }

            return new Transactions
            {
                
            };
        }
    }
}
