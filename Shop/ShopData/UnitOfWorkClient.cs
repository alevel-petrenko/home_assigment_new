using ShopData.DataModels;
using ShopData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopData
{
    public interface IUnitOfWork
    {
        void Save();

        EFClientRepository EFClientRepository { get; }
        EFTransactionsRepository EFTransactionsRepository { get; }
        EFUserCategoryRepository EFUserCategoryRepository { get; }

        void Dispose();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ShopDataModel context = new ShopDataModel();

        private EFClientRepository _eFClientRepository;

        public virtual EFClientRepository EFClientRepository
        {
            get
            {
                if (_eFClientRepository == null)
                {
                    _eFClientRepository = new EFClientRepository(context);
                }
                return _eFClientRepository;
            }
        }

        private EFTransactionsRepository _eFTransactionsRepository;

        public EFTransactionsRepository EFTransactionsRepository
        {
            get
            {
                if (_eFTransactionsRepository == null)
                {
                    _eFTransactionsRepository = new EFTransactionsRepository(context);
                }
                return _eFTransactionsRepository;
            }
        }

        private EFUserCategoryRepository _eFUserCategoryRepository;

        public EFUserCategoryRepository EFUserCategoryRepository
        {
            get
            {
                if (_eFUserCategoryRepository == null)
                {
                    _eFUserCategoryRepository = new EFUserCategoryRepository(context);
                }
                return _eFUserCategoryRepository;
            }
        }

        public void Save ()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
