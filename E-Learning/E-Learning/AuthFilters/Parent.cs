using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace E_Learning.AuthFilters
{
    public class Parent : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;
            if (header == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No token supplied" });
            }
            else
            {
                var token = header.Parameter.ToString();
                if (token != null && !AuthService.IsTeacher(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "Supplied token in invalid or expired" });
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}