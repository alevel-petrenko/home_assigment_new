using BussinesLogic.Extensions;
using BussinesLogic.Model;
using BussinesLogic.Service;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    public class UserCategoryController : ApiController
    {
        private readonly IUserCategoryService _userCategory;

        public UserCategoryController()
        {
            _userCategory = new UserCategoryService();
        }

        public UserCategoryController(IUserCategoryService uCS)
        {
            _userCategory = uCS;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _categoriesList = _userCategory.GetAll().Select(uc => uc.ToViewModel());

            return Ok(_categoriesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var client = _userCategory.Get(id).ToViewModel();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] UserCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                int categoryId = _userCategory.Add(model.ToDTOModel());
                return Ok(categoryId);
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] UserCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userCategory.Update(model.ToDTOModel());
            }
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                _userCategory.Delete(id.Value);
                return Ok();
            }
            else return BadRequest();
        }
    }
}
