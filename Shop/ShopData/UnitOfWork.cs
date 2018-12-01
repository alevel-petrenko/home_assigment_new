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
    public class UnitOfWork : IDisposable
    {
        private ShopDataModel context = new ShopDataModel();

        private EFClientRepository _eFClientRepository;

        public EFClientRepository eFClientRepository
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

        //public EFClientRepository ClientRepository
        //{
        //    get
        //    {
        //        if (_clientRepository == null)
        //        {
        //            _eFClientRepository = new EFClientRepository(context);
        //        }
        //        return _eFClientRepository;
        //    }
        //}

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
