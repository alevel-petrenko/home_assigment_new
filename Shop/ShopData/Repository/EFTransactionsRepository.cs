using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    public class EFTransactionsRepository : ITransactionsRepository
    {
        public EFTransactionsRepository(ShopDataModel context)
        {
            _context = context;
        }

        private ShopDataModel _context;

        public int Add(Transactions transactions)
        {
            _context.Transactions.Add(transactions);
            return transactions.Id;
        }

        public void Delete(int id)
        {
            var transaction = Get(id);
            transaction.IsDeleted = true;
        }

        public Transactions Get(int id)
        {
            return _context.Transactions.FirstOrDefault(a => a.Id == id);
        }

        public List<Transactions> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public void Update(Transactions transaction)
        {
            var oldTransaction = Get(transaction.Id);
            oldTransaction.Amount = transaction.Amount;
        }
    }
}
