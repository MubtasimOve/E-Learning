using BLL.Services;
using E_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace E_Learning.Controllers

{
    public class Login_Controller : ApiController
    {
       
        
            [HttpPost]
            [Route("api/login")]
            public HttpResponseMessage Login(LoginModel login)
            {
                try
                {
                    var token = AuthService.Login(login.Username, login.Password);
                    if (token != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, token);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
                    }

                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
    }
