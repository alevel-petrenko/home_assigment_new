using System;
using System.Collections.Generic;
using System.Linq;
using ShopData;
using ShopData.DTO__BusinessModels_;
using ShopData.Extensions;
using BussinesLogic.Model;

namespace BussinesLogic.Service
{
    public interface IUserCategoryService
    {
        int Add(UserCategoryDTO clientDTO);

        void Delete(int id);

        void Update(UserCategoryDTO clientDTO);

        List<UserCategoryDTO> GetAll();

        UserCategoryDTO Get(int id);
    }

    public class UserCategoryService : IUserCategoryService
    {
        private UnitOfWork _uOW;

        public UserCategoryService()
        {
            if (_uOW == null)
            _uOW = new UnitOfWork();
        }

        public UserCategoryService(UnitOfWork uoW)
        {
            _uOW = uoW;
        }

        public int Add(UserCategoryDTO categoryDto)
        {
            var category = categoryDto.To_SQLModel();
            _uOW.EFUserCategoryRepository.Add(category);
            _uOW.Save();

            return category.Id;
        }

        public void Delete(int id)
        {
            var category = Get(id);

            category.IsDeleted = true;
            _uOW.Save();
        }

        public virtual UserCategoryDTO Get(int id)
        {
            return _uOW.EFUserCategoryRepository.Get(id).To_DTOModel();
        }

        public virtual List<UserCategoryDTO> GetAll()
        {
            return _uOW.EFUserCategoryRepository.GetAll()
                .Select(a => a.To_DTOModel()).ToList();
        }

        public void Update(UserCategoryDTO categoryDto)
        {
            var client = categoryDto.To_SQLModel();
        }
    }
}
