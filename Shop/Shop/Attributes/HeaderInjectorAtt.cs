﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Shop.Attributes
{
    public class HeaderInjectorAtt : ActionFilterAttribute
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            var result = await continuation();

            result.StatusCode = System.Net.HttpStatusCode.OK;
            result.Headers.Add("Hello", "Hello");

            return result;
        }
    }
}