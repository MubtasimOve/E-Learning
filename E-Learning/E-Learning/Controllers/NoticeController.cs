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
    public class NoticeController : ApiController
    {
        [Teacher]
        [HttpPost]
        [Route("api/Notice/add")]
        public HttpResponseMessage Add(NoticeDTO obj)
        {
            try
            {
                var data = NoticeService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/Notice/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = NoticeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [Teacher]
        [HttpGet]
        [Route("api/Notice/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = NoticeService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Teacher]
        [HttpPost]
        [Route("api/Notice/update")]
        public HttpResponseMessage update(NoticeDTO obj)
        {
            try
            {
                var data = NoticeService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Notice/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = NoticeService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/notice/title/{name}")]
        public HttpResponseMessage GetByName(string title)
        {
            try
            {
                var data = false;
                if (data == true)
                {
                    NoticeService.GetByName(title);
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
