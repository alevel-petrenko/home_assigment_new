using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BussinesLogic.Extensions;
using BussinesLogic.Model;
using BussinesLogic.Service;
using Shop.Attributes;

namespace Shop.Controllers
{
    [RoutePrefix("api/clients")]
    //[ZeroHandlerAtt]
    [OverrideActionFilters]
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController()
        {
            _clientService = new ClientService();
        }

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
        public IHttpActionResult GetDetails (int id)
        {
            var client = _clientService.Get(id).toViewModel();

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] ClientViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            if (_clientService.Validate(model.Name))
                return BadRequest("Duplicate") ;

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

        [Route("get-limited/{number}")]
        [HttpGet]
        [NumberExceptionAtt]
        public IHttpActionResult GetLimited(int? number)
        {
            //if (number == null)
            //return BadRequest();

            //if (number <= 0)
            //    return BadRequest();

            var clients = _clientService.GetLimited(number.Value);

            return Ok(clients);
        }
    }
}
