using BussinessLogic.Models;
using BussinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace McDonalds.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductService _productsService = new ProductServices();

        [HttpGet, Route("")] //может быть переименнован
        public IHttpActionResult GetAll()
        {
            var products = _productsService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = _productsService.Get(id);
            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productsService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            _productsService.Update(product);

            return Ok();
        }

        [HttpPost, Route("")]
        public IHttpActionResult Add([FromBody] Product product)
        {
            _productsService.Add(product);

            return Ok();
        }
    }
}
