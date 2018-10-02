using BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public interface IProductService
    {
        Product Get(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetAll();
    }
}
