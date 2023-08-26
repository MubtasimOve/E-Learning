using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Learning.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("api/Registration/add")]

        public HttpResponseMessage Add(RegistrationDTO obj)
        {
            try
            {
                var data = RegistrationService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/Registration/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = RegistrationService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/Registration/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RegistrationService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Registration/update")]
        public HttpResponseMessage update(RegistrationDTO obj)
        {
            try
            {
                var data = RegistrationService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Registration/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = RegistrationService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
    }
}
