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
    public class ItemGrpApiController : ApiController
    {
        // GET: api/ItemGrp
        [Route("ItemGrp")]
        public HttpResponseMessage GetItemGrps()
        {
            var result = new ItemGrpData_Crud().ItemGrp_GetAll();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, result);
        }

        // GET: api/ItemGrp/5
        public HttpResponseMessage GetItemGrp(int PID)
        {
            var result = new ItemGrpData_Crud().ItemGrp_GetById(PID);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, result);
        }

        // POST: api/ItemGrp
        [HttpPost]
        public HttpResponseMessage PostItemGrp(ItemGrp itemGrp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ItemGrpData_Crud().ItemGrp_Insert(itemGrp);

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

        // PUT: api/ItemGrp/5
        [HttpPut]
        public HttpResponseMessage PutItemGrp(ItemGrp itemGrp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ItemGrpData_Crud().ItemGrp_Update(itemGrp);

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

        // DELETE: api/ItemGrp/5
        [HttpDelete]
        public HttpResponseMessage DeleteItemGrp(int PID)
        {
            var result = new ItemGrpData_Crud().ItemGrp_Delete(PID);
            if (result == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result = new ItemGrpData_Crud().ItemGrp_Delete(PID);
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
