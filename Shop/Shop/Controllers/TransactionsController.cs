using BussinesLogic.Extensions;
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
    public class TransactionsController : ApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController()
        {
            _transactionService = new TransactionService();
        }

        public TransactionsController(ITransactionService ts)
        {
            _transactionService = ts;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _transactionsList = _transactionService.GetAll().Select(b => b.ToViewModel());

            return Ok(_transactionsList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var client = _transactionService.Get(id).ToViewModel();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] TransactionViewModel model)
        {
            int clientId = _transactionService.Add(model.ToDTOModel());

            return Ok(clientId);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] TransactionViewModel model)
        {
            _transactionService.Update(model.ToDTOModel());

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _transactionService.Delete(id);

            return Ok();
        }
    }
}
