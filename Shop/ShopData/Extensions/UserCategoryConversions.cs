using ShopData.DataModels;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Extensions
{
    public static class UserCategoryConversions
    {
        public static UserCategoryDTO To_DTOModel (this UserCategory category)
        {
            if (category == null)
            {
                return null;
            }

            return new UserCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                IsDeleted = category.IsDeleted
            };
        }

        public static UserCategory To_SQLModel(this UserCategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return null;
            }

            return new UserCategory
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                IsDeleted = categoryDto.IsDeleted
            };
        }
    }
}
