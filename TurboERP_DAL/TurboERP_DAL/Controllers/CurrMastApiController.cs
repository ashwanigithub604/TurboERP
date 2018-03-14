using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurboERP_DAL.Models;
using TurboERP_DAL.App_DAL;
using System.Web.Http.Description;

namespace TurboERP_DAL.Controllers
{
    public class CurrMastApiController : ApiController
    {
        // GET: api/CurrMast
        [Route("Currency")]
        public HttpResponseMessage GetCurrMasts()
        {
            var result = new CurrMastData_Crud().CurrMast_GetAll();
            if(result !=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, result);
        }

        //GET: api/CurrMast/5
        public HttpResponseMessage GetCurrMast(int PID)
        {
            var result = new CurrMastData_Crud().CurrMast_GetById(PID);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, result);
        }

        // POST: api/CurrMast
        [HttpPost]
        public HttpResponseMessage PostCurrMast(CurrMast currMast)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new CurrMastData_Crud().CurrMast_Insert(currMast);

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

        // PUT: api/CurrMast/5
        [HttpPut]
        public HttpResponseMessage PutCurrMast(CurrMast currMast)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new CurrMastData_Crud().CurrMast_Update(currMast);

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

        // DELETE: api/CurrMast/5
        [HttpDelete]
        public HttpResponseMessage DeleteCurrMast(int PID)
        {
            var result = new CurrMastData_Crud().CurrMast_Delete(PID);
            if (result == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result = new CurrMastData_Crud().CurrMast_Delete(PID);
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
