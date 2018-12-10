using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ClientApiIntegrationTest
    {
        //на АПИ не работает TransactionScope
        private HttpClient _httpClient;
        private ShopDataModel _ctx;
        private int _id = 22;//hardcode

        [TestInitialize]
        public void Initializer ()
        {
            _httpClient = new HttpClient();
            _ctx = new ShopDataModel();

            _httpClient.BaseAddress = new Uri("http://localhost:59794/api"); //???
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _ctx.Database.ExecuteSqlCommand("Insert into Client ([name], IsDeleted) Values 'TestApi', '0'");
        }

        [TestCleanup]
        public void Destroyer ()
        {
            _ctx.Database.ExecuteSqlCommand($"Delete from Client ([name], IsDeleted) where Id = {_id}");
        }

        [TestMethod]
        public async void Test_GetClients ()
        {
            //Assign
            var count = _ctx.Clients.Count(a => a.IsDeleted.HasValue || a.IsDeleted.Value);

            //Action
            var result = await _httpClient.GetAsync("clients");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);

            var list = await result.Content.ReadAsAsync<List<Client>>();
            //Assert
            Assert.AreEqual(count, list.Count);
        }
    }
}
