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
                Client = new ClientDTO
                {
                    Name = transactions.Client.Name,
                    Id = transactions.Client.Id
                }
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
                Id = transactionsDTO.Id,
                Date = transactionsDTO.Date,
                Amount = transactionsDTO.Amount,
                Client = new Client
                {
                    Name = transactionsDTO.Client.Name,
                    Id = transactionsDTO.Client.Id
                }
            };
        }
    }
}
