using BussinesLogic.Model;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Extensions
{
    public static class UserCategoryConvertion
    {
        public static UserCategoryViewModel ToViewModel (this UserCategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return null;
            }

            return new UserCategoryViewModel
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            };
        }

        public static UserCategoryDTO ToDTOModel(this UserCategoryViewModel categoryView)
        {
            if (categoryView == null)
            {
                return null;
            }

            return new UserCategoryDTO
            {
                Name = categoryView.Name,
                Id = categoryView.Id
            };
        }
    }
}