using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData;
using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    class TransactionIntegrationTest
    {
        private UnitOfWork _uOW;
        private ShopDataModel _ctx;

        [TestInitialize]
        public void Initialize()
        {
            _uOW = new UnitOfWork();
            _ctx = new ShopDataModel();
        }
    }
}
