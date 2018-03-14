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
    public class UnitApiController : ApiController
    {
       
        [Route("Unit")]
        public HttpResponseMessage GetUnits()
         {
            var units = new UnitMaster().Unit_GetAll();
            if (units != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, units);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, units);
        }

        // GET: api/GetUnit/2
        [ResponseType(typeof(UnitMast))]
        public UnitMast GetUnit(int? Pid)
        {
            var unit = new UnitMaster().Unit_GetById(Pid);
            return unit;
        }

        // POST: api/PostUnit/
        [HttpPost]
        public HttpResponseMessage PostUnit(UnitMast unit)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new UnitMaster().Unit_Insert(unit);

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

        // PUT: api/PutUnit/5
        [HttpPut]
        public HttpResponseMessage PutUnit(UnitMast unit)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new UnitMaster().Unit_Update(unit);

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


        // DELETE: api/DeleteUnit/5 
        [HttpDelete]
        public HttpResponseMessage DeleteUnit(int Pid)
        {
            var result = new UnitMaster().Unit_GetById(Pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = new UnitMaster().Unit_Delete(Pid);
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
