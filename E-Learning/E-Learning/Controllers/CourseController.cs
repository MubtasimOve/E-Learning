
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
    public class CourseController : ApiController
    {
        [Teacher]
        [HttpPost]
        [Route("api/Course/add")]
        public HttpResponseMessage Add(CourseDTO obj)
        {
            try
            {
                var data = CourseService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/Course/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = CourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Teacher]
        [HttpGet]
        [Route("api/Course/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CourseService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Course/update")]
        public HttpResponseMessage update(CourseDTO obj)
        {
            try
            {
                var data = CourseService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Course/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CourseService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Course/name/{name}")]
        public HttpResponseMessage GetByName(string name)
        {
            try
            {
                var data = false;
                if (data == true)
                {
                    CourseService.GetByName(name);
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
        [HttpGet]
        [Route("api/Course/lessons/{courseName}")]
        public HttpResponseMessage GetLessonsByCourseName(string courseName)
        {
            try
            {
                var data = lessonService.GetLessonsByCourseName(courseName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
      }
}
