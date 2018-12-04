using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ClientIntegrationTest
    {
        public ClientIntegrationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
            using (var ctx = new EntityFW())
            {

            }
        }

        [TestMethod]
        public void TestClientAdding ()
        {
            //Assign
            using (var ctx = new ShopDataModel())
            {
                int count = ctx.Client;
                
                using (var ts = new Trans)
            }
        }
    }
}

//try test на добавление в базу
// сделать DI здесь
// почитать про Transactions