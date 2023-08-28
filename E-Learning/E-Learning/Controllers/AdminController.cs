using BLL.DTOs;
using BLL.Services;
using E_Learning.AuthFilters;
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
        [Teacher]
        [HttpPost]
        [Route("api/lesson/add")]
        public HttpResponseMessage Add(LessonDTO obj)
        {
            try
            {
                var data = lessonService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
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


        [Teacher]
        [HttpGet]
        [Route("api/lesson/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = lessonService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Teacher]
        [HttpPost]
        [Route("api/lesson/update")]
        public HttpResponseMessage update(LessonDTO obj)
        {
            try
            {
                var data = lessonService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/lesson/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = lessonService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/lesson/title/{name}")]
        public HttpResponseMessage GetByName(string title)
        {
            try
            {
                var data = false;
                if (data == true)
                {
                    lessonService.GetByName(title);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Found" });
                }
                    
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
