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
        public static TransactionDTO to_DTOModel(this Transactions transactions)
        {
            if (transactions == null)
            {
                return null;
            }

            return new TransactionDTO
            {
                Id = transactions.Id,
                Date = transactions.Date.Value,
                Amount = transactions.Amount.Value,
                Client = transactions.Client.to_DTOModel()
            };
        }

        public static Transactions to_SQLModel(this TransactionDTO transactionsDTO)
        {
            if (transactionsDTO == null)
            {
                return null;
            }

            return new Transactions
            {
                Id = transactionsDTO.Id,
                Date = transactionsDTO.Date,
                Amount = transactionsDTO.Amount,
                Client = transactionsDTO.Client.to_SQLModel()
            };
        }
    }
}
