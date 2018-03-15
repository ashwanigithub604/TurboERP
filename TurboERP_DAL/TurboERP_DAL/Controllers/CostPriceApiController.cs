using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TurboERP_DAL.App_DAL;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class CostPriceApiController : ApiController
    {

        [Route("CostPrice")]
        public HttpResponseMessage GetCostPrices()
        {
            var costPrices = new CostPrice().CostPrice_GetAll();
            if (costPrices != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, costPrices);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, costPrices);
        }

        // GET: api/GetCostPrice/2
        public CPMaster GetCostPrice(int? Pid)
        {
            var costPrice = new CostPrice().CostPrice_GetById(Pid);
            return costPrice;
        }

        // POST: api/PostCostPrice/
        [HttpPost]
        public HttpResponseMessage PostCostPrice(CPMaster costPrice)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new CostPrice().CostPrice_Insert(costPrice);

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

        // PUT: api/PutCostPrice/5
        [HttpPut]
        public HttpResponseMessage PutCostPrice(CPMaster costPrice)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new CostPrice().CostPrice_Update(costPrice);

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


        // DELETE: api/DeleteCostPrice/5 
        [HttpDelete]

        public HttpResponseMessage DeleteCostPrice(int pid)
        {
            var result = new CostPrice().CostPrice_GetById(pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = new CostPrice().CostPrice_Delete(pid);
                if (result.PID != 0)
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

  

