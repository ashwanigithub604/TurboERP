using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurboERP_DAL.App_DAL;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class CourierApiController : ApiController
    {


        [HttpGet]
        [Route("Courier")]
        public HttpResponseMessage GetCourierGrid()
        {
            try
            {
                var CourierDt = new Couriercls().GetCourierGrid();
                if (CourierDt != null)
                    return Request.CreateResponse(HttpStatusCode.OK, CourierDt);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, CourierDt);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetCourierById(int PID)
        {
            try
            {
                var salesCoDt = new Couriercls().GetCourierById(PID);
                if (salesCoDt != null)
                    return Request.CreateResponse(HttpStatusCode.OK, salesCoDt);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, salesCoDt);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage InsertCourier(MisPrty misPrty)
        {
            try
            {
                int result = new Couriercls().InsertCourier(misPrty);
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateCourier(MisPrty misPrty)
        {
            try
            {
                int result = new Couriercls().UpdateCourier(misPrty);
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }

        }

        [HttpDelete]
        public HttpResponseMessage DeleteCourier(int PID)
        {
            try
            {
                int result = new Couriercls().DeleteCourier(PID);
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }


    }
}
