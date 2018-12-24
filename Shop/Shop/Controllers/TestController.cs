using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    public class TestController : ApiController
    {
        [OverrideActionFilters]
        public IHttpActionResult Tets ()
        {
            throw new DivideByZeroException("Boom");
        }

        [HttpPost]
        public IHttpActionResult TestGet ()
        {
            return Ok();
        }
    }
}
