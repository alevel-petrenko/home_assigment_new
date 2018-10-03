using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Models;
using Newtonsoft.Json;
using static BussinessLogic.Category;

namespace BussinessLogic.Services
{
    public class ProductServices : IProductService
    {
        private static List<Product> _products = new List<Product>();
        private const string _path = @"E:\A_level\Git\home_assigment_new\McDonalds\Products.txt";

        private void Save()
        {
            string productList = JsonConvert.SerializeObject(_products);
            File.WriteAllText(_path, productList);
        }

        static ProductServices()
        {
            _products.Add(new Product
            {
                Category = CategoryType.Beverage,
                Name = "Big mak",
                Id = 1,
                StartHappyHours = 19,
                EndHappyHours = 23,
                Price = 15
            });

            var productCollection = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_path));
            _products = productCollection;
        }

        public void Add(Product product)
        {
            product.Id = GetMaxId();
            _products.Add(product);

            Save();
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if(product != null)
            _products.Remove(product);

            Save();
        }

        public Product Get(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(x => x.Name).ToList();
        }

        public void Update(Product product)
        {
            var oldProduct = Get(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Category = product.Category;
            oldProduct.Price = product.Price;
            oldProduct.StartHappyHours = product.StartHappyHours;
            oldProduct.EndHappyHours = product.EndHappyHours;

            Save();
        }

        public int GetMaxId()
        {
            const int seed = 1;

            if (_products != null && _products.Any())
                return 1;
            else
                return _products.Max(x => x.Id) + seed;
        }
    }
}
