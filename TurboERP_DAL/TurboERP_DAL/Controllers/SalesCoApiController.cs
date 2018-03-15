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
    public class SalesCoApiController : ApiController
    {

        [HttpGet]
        [Route("SalesCo")]
        public HttpResponseMessage GetSalesCoordinotorGrid()
        {
            try
            {
                var salesCoDt = new SalesCocls().GetSalesCoordinotorGrid();
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


        [HttpGet]
        public HttpResponseMessage GetSalesCoordinatorById(int PID)
        {
            try
            {
                var salesCoDt = new SalesCocls().GetSalesCoordinatorById(PID);
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
        public HttpResponseMessage InsertSalesCoordinator(MisPrty misPrty)
        {
            try
            {
                int result = new SalesCocls().InsertSalesCoordinator(misPrty);
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
        public HttpResponseMessage UpdateSalesCoordinator(MisPrty misPrty)
        {
            try
            {
                int result = new SalesCocls().UpdateSalesCoordinator(misPrty);
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
        public HttpResponseMessage DeleteSalesCo(int PID)
        {
            try
            {
                int result = new SalesCocls().DeleteSalesCo(PID);
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

