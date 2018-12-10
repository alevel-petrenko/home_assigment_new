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
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ShopDataModel context = new ShopDataModel();

        private EFClientRepository _EFClientRepository;

        public EFClientRepository EFClientRepository
        {
            get
            {
                if (_EFClientRepository == null)
                {
                    _EFClientRepository = new EFClientRepository(context);
                }
                return _EFClientRepository;
            }
        }

        private EFTransactionsRepository _EFTransactionsRepository;

        public EFTransactionsRepository EFTransactionsRepository
        {
            get
            {
                if (_EFTransactionsRepository == null)
                {
                    _EFTransactionsRepository = new EFTransactionsRepository(context);
                }
                return _EFTransactionsRepository;
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
