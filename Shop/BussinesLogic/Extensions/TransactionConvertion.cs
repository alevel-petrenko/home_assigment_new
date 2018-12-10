using BussinesLogic.Model;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Extensions
{
    public static class TransactionConvertion
    {
        public static TransactionViewModel ToViewModel (this TransactionDTO transactionDTO)
        {
            if (transactionDTO == null)
            {
                return null;
            }

            return new TransactionViewModel
            {
                Id = transactionDTO.Id,
                Date = transactionDTO.Date,
                Amount = transactionDTO.Amount,
                Client = transactionDTO.Client.toViewModel()
            };
        }

        public static TransactionDTO ToDTOModel(this TransactionViewModel transactionView)
        {
            if (transactionView == null)
            {
                return null;
            }

            return new TransactionDTO
            {
                Id = transactionView.Id,
                Date = transactionView.Date,
                Amount = transactionView.Amount,
                Client = transactionView.Client.toDTOModel()
            };
        }
    }
}

//задача: Как не делать двойную конвертацию? use genetic methods