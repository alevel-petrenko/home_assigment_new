﻿using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAuthorization.Controllers
{
    [RoutePrefix("api/UsersDB")]
    public class UsersDBController : ApiController
    {
        //IsDelete флаг для пометки на удаление.
        //Возвращать из базы нужно только те поля, которые не помечен на удаление IsDeleted=True

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            using (var context = new UsersDB())
            {
                var values = context.Users.ToList();

                return Ok(values);
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            using (var context = new UsersDB())
            {
                context.Users.Add(null);

                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var context = new UsersDB())
            {
                var user = context.Users.Where(us => us.UserId == id);

                return Ok();
            }
        }

        private ICollection<User> GetAllUsers()
        {
            using (var context = new UsersDB())
            {
                var values = context.Users.ToList();

                return values;
            }
        }
    }
}
