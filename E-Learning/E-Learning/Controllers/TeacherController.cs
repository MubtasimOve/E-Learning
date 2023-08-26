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
    [Teacher]
    [Logged]


    public class TeacherController : ApiController
    {

        [HttpPost]

        [Route("api/Teacher/add")]

        public HttpResponseMessage Add(TeacherDTO obj)
        {
            try
            {

                var token = Request.Headers.Authorization.ToString();
                var teacherID = AuthService.IsTeacher(token);
                var data = TeacherService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

               
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
       
        [HttpGet]
        [Route("api/Teacher/all")]
        public HttpResponseMessage All()
        {
            try
            {

                var token = Request.Headers.Authorization.ToString();
                var data = TeacherService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/Teacher/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = TeacherService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Teacher/update")]
        public HttpResponseMessage update(TeacherDTO obj)
        {
            try
            {
                var data = TeacherService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Teacher/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TeacherService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Teacher/name/{name}")]
        public HttpResponseMessage GetByName(string name)
        {
            try
            {
                var data = false;
                if (data == true)
                {
                    TeacherService.GetByName(name);
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
