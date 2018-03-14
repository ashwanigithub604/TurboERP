using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurboERP_DAL.Models;
using TurboERP_DAL.App_DAL;

namespace TurboERP_DAL.Controllers
{
    public class SkuMastApiController : ApiController
    {
        // GET: api/SkuMast
        [Route("SkuMast")]
        public HttpResponseMessage GetSkuMasts()
        {
            var skuMasts = new SkuMastData_Crud().SkuMast_GetAll();
            if (skuMasts != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, skuMasts);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, skuMasts);
        }

        // GET: api/SkuMast/5
        public HttpResponseMessage GetSkuMast(int PID)
        {
            var skuMast = new SkuMastData_Crud().SkuMast_GetById(PID);
            if (skuMast != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, skuMast);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, skuMast);
        }

        // POST: api/SkuMast
        [HttpPost]
        public HttpResponseMessage PostSkuMast(SkuMast skuMast)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new SkuMastData_Crud().SkuMast_Insert(skuMast);

                    if (result != null || result != "")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, result);
                    }

                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/SkuMast/5
        [HttpPut]
        public HttpResponseMessage PutSkuMast(SkuMast skuMast)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new SkuMastData_Crud().SkuMast_Update(skuMast);

                    if (result != null || result != "")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, result);
                    }

                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/SkuMast/5
        [HttpDelete]
        public HttpResponseMessage DeleteSkuMast(int PID)
        {
            var result = new SkuMastData_Crud().SkuMast_Delete(PID);
            if (result == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result = new SkuMastData_Crud().SkuMast_Delete(PID);
                if (result != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
        }

    } 
}
