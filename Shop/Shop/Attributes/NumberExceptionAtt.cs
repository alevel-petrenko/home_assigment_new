using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Shop.Attributes
{
    public class NumberExceptionAtt : Attribute, IExceptionFilter
    {
        public bool AllowMultiple
        {
            //может ли вызываться в одном экшене неск раз?
            get
            {
                return false;
            }
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null
                && actionExecutedContext.Exception is ArgumentException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, "Number is more than amount if items");
            }

            return Task.FromResult<object>(null);
        }
    }
}