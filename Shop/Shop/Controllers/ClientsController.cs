using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BussinesLogic.Extensions;
using BussinesLogic.Model;
using BussinesLogic.Service;

namespace Shop.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IHttpActionResult GetAll ()
        {
            var _clientList = _clientService.GetAll().Select(b => b.toViewModel());
            
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
            _clientService.Delete(id);

            return Ok();
        }
    }
}
