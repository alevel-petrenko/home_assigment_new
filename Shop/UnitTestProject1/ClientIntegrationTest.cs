using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData.DataModels;
using System.Linq;
using ShopData;
using System.Transactions;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ClientIntegrationTest
    {
        private UnitOfWork _uOW;
        private ShopDataModel _ctx;

        [TestInitialize]
        public void Initialize ()
        {
            _uOW = new UnitOfWork();
            _ctx = new ShopDataModel();
        }

        public ClientIntegrationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGet()
        {
            //Assign
            int val = 5;
            // Act
            var result = Divide(val);
            //Assert
            Assert.AreEqual(1, result);
        }

        private double Divide(int value)
        {
            return (double) 5 / value;
        }

        [TestMethod]
        public void TestGet2 ()
        {
            //Assign
            int val = 10;
            // Act
            var result = Divide(val);
            //Assert
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestGet3()
        {
            //Assign
            int val = 0;
            // Act
            var result = Divide(val);
            //Assert
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void TestDbRecording ()
        {
            using (var ctx = new ShopDataModel())
            {

            }
        }

        [TestMethod]
        public void TestClientAdding ()
        {
            //Assign
            using (var ctx = new ShopDataModel())
            {
                //int count = ctx.Clients;
                
                //using (var ts = new TransactionScope)
                {}
            }
        }

        [TestMethod]
        public void Test_GetDetails()
        {
            //Assign
            var ctx = new ShopDataModel();
            var client = ctx.Clients.FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);
            //Action
            var uOwClient = _uOW.EFClientRepository.Get(client.Id);
            //Assert
            Assert.AreEqual(client.Id, uOwClient.Id);
            Assert.AreEqual(client.Name, uOwClient.Name);
            Assert.AreEqual(client.IsDeleted, uOwClient.IsDeleted);
            Assert.AreEqual(client.Transactions, uOwClient.Transactions);
        }

        [TestMethod]
        public void Test_GetDetails_ExistingItem()
        {
            //Assign

            var ctx = new ShopDataModel();
            var client = ctx.Clients.FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);
            //Action
            if (client == null)
            {
                Assert.IsTrue(true, "Emplty recordset");
                return;
            }

            var uOwClient = _uOW.EFClientRepository.Get(client.Id);
            //Assert

            Assert.AreEqual(client.Id, uOwClient.Id);
            Assert.AreEqual(client.Name, uOwClient.Name);
            Assert.AreEqual(client.IsDeleted, uOwClient.IsDeleted);
            Assert.AreEqual(client.Transactions, uOwClient.Transactions);
        }

        [TestMethod]
        public void Test_GetDetails_Nullable()
        {
            //Assign
            var ctx = new ShopDataModel();
            var maxId = ctx.Clients.Max(c => c.Id) + 1;

            //Action
            var client = _uOW.EFClientRepository.Get(maxId);

            //Assert
            Assert.IsNull(client);
        }

        [TestMethod]
        public void Test_GetDetails_DeleteClients()
        {
            //Assign
            var ctx = new ShopDataModel();
            var deletedClient = ctx.Clients.FirstOrDefault(c => c.IsDeleted.HasValue);

            //Action
            if(deletedClient == null)
            {
                Assert.IsTrue(true, "No deleted client");
                return;
            }

            var client = _uOW.EFClientRepository.Get(deletedClient.Id);

            //Assert
            Assert.IsNull(client);
        }

        [TestMethod]
        public void Test_DeleteClient()
        {
            //Assign
            var ctx = new ShopDataModel();
            var deletedClient = ctx.Clients.FirstOrDefault(c => c.IsDeleted.HasValue);

            //Action
            

            //Assert
            

        }

        [TestMethod]
        public void Test_UpdateClient()
        {
            //Assign
            var ctx = new ShopDataModel();
            var deletedClient = ctx.Clients.FirstOrDefault(c => c.IsDeleted.HasValue);

            //Action


            //Assert


        }
    }
}

//Hommetask
//try test на добавление в базу
// сделать DI здесь
// почитать про Transactions