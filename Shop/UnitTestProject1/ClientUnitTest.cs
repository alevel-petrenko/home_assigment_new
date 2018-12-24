using BussinesLogic.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopData;
using ShopData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ClientUnitTest
    {
        private Mock<EFClientRepository> _mockedEfRepo;

        [TestInitialize]
        public void Initialize()
        {
            _mockedEfRepo = new Mock<EFClientRepository>();
        }

        [TestMethod]
        public void CheckLimited()
        {
            //Assign
            var mockedEfRepo = new Mock<EFClientRepository>();
            mockedEfRepo.Setup(x => x.GetAll())
                .Returns(new List<ShopData.DataModels.Client>
                {
                    new ShopData.DataModels.Client
                    {
                        Id=1,
                        Name="Kyk",
                        IsDeleted = false
                    }
                });
            var mockedUow = new Mock<UnitOfWork>();
            mockedUow.Setup(x => x.EFClientRepository).Returns(mockedEfRepo.Object);

            int number = 1;

            var clientService = new ClientService(mockedUow.Object);

            var res =clientService.GetLimited(number);

            Assert.AreEqual(number, res.Count);
        }

        [TestMethod]
        public void CheckSearch()
        {
            //Assign
            var mockedEfRepo = new Mock<EFClientRepository>();

            mockedEfRepo.Setup(x => x.GetAll()).Returns(
                new List<ShopData.DataModels.Client>
                {
                    new ShopData.DataModels.Client
                    {
                        Id=1,
                        Name="test1"
                    },
                    new ShopData.DataModels.Client
                    {
                        Id=2,
                        Name="test0"
                    },
                     new ShopData.DataModels.Client
                    {
                        Id=3,
                        Name="opop"
                    }
                });

            var mockedUow = new Mock<UnitOfWork>();
            mockedUow.Setup(x => x.EFClientRepository).Returns(mockedEfRepo.Object);

            var clientService = new ClientService(mockedUow.Object);

            string searchParam = "opop";
            //Act
            var filteredList = clientService.Search(searchParam);

            //Assert
            Assert.AreEqual(2, filteredList.Count);
        }
    }
}
