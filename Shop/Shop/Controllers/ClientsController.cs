using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.BussinesLogic;

namespace Shop.Controllers
{
    public class ClientsController : ApiController
    {
        private IClientService _clientService = new IClientService();

        [HttpGet]
        public IHttpActionResult GetAll ()
        {
            var _clientList = _clientService.Get().Select(b => b.toViewModel());

            return Ok(_clientList);
        }

        [HttpGet]
        public IHttpActionResult Get (int id)
        {
            var client = _clientService.Get(id).toViewModel();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] ClientViewModel model)
        {
            int clientId = _clientService.Add(model.toDTOModel());

            return Ok(clientId);
        }

        [HttpPut]
        public IHttpActionResult Update ([FromBody] ClientViewModel model)
        {
            _clientService.Update(model.toDTOModel());

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete (int id)
        {
            _clientService.Delete();

            return Ok();
        }
    }
}
