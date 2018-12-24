using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    public interface IUserCategoryRepository
    {
        int Add(UserCategory category);

        void Update(UserCategory category);

        void Delete(int id);

        List<UserCategory> GetAll();

        UserCategory Get(int id);
    }

    public class EFUserCategoryRepository : IUserCategoryRepository
    {
        public EFUserCategoryRepository(ShopDataModel context)
        {
            _context = context;
        }

        private ShopDataModel _context;

        public int Add(UserCategory category)
        {
            _context.UserCategory.Add(category);
            return category.Id;
        }

        public void Delete(int id)
        {
            var category = Get(id);
            category.IsDeleted = true;
        }

        public UserCategory Get(int id)
        {
            return _context.UserCategory.FirstOrDefault(a => a.Id == id);
        }

        public List<UserCategory> GetAll()
        {
            return _context.UserCategory.ToList();
        }

        public void Update(UserCategory category)
        {
            var oldCategory = Get(category.Id);
            oldCategory.Name = category.Name;
        }
    }
}
