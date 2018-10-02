using BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace McDonalds.Services
{
    public interface IHttpProductService
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> Get(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }

    public class HttpProductService : IHttpProductService
    {
        static HttpClient _httpClient;

        static HttpProductService()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(Properties.Settings.Default.api); //поменяли адрес в properties
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Add(Product product)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Product>(product);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<Product>>();
            }
            return product;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id)
        {
            Product product = null;

            string url = $"products/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<Product>>();
            }
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = null;

            HttpResponseMessage response = await _httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<Product>>();
            }
            return products;

            // контроллеры в mvc тоже async
            // реализовать перехвать ошибки если NotFound!!!
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}