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
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/lesson/add")]
        
        public HttpResponseMessage Add(LessonDTO obj)
        {
            try
            {
                var data = lessonService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/lesson/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = lessonService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
