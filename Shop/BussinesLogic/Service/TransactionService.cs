using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;
using ShopData;
using ShopData.DTO__BusinessModels_;
using ShopData.Extensions;
using BussinesLogic.Model;

namespace BussinesLogic.Service
{
    public interface ITransactionService
    {
        bool Validate(string name);

        int Add(TransactionDTO transactionDTO);
        void Delete(int id);
        void Update(TransactionDTO transactionDTO);
        List<TransactionDTO> GetAll();
        TransactionDTO Get(int id);
    }

    public class TransactionService : ITransactionService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(TransactionDTO transactionDTO)
        {
            var transaction = transactionDTO.to_SQLModel();
            _uOW.EFTransactionsRepository.Add(transaction);
            _uOW.Save();

            return transaction.Id;
        }

        public void Delete(int id)
        {
            var transaction = Get(id);

            transaction.IsDeleted = true;
            _uOW.Save();
        }

        public TransactionDTO Get(int id)
        {
            return _uOW.EFTransactionsRepository.Get(id).to_DTOModel();
        }

        public List<TransactionDTO> GetAll()
        {
            return _uOW.EFTransactionsRepository.GetAll().Select(a => a.to_DTOModel()).OrderBy(x => x.Date).ToList();
        }

        public void Update(TransactionDTO transactionDTO)
        {
            var transaction = transactionDTO.to_SQLModel();
        }

        public bool Validate(string name)
        {
            return true;
        }
    }
}
