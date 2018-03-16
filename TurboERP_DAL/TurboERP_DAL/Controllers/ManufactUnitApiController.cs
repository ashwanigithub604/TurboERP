using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TurboERP_DAL.App_DAL;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class ManufacturingUnitApiController : ApiController
    {
        [Route("ManufacturingUnit")]
        public HttpResponseMessage GetManufacturingUnit()
        {
            var ManUnit = new ManufacturingUnit_CRUD().ManufacturingUnit_GetAll();
            if (ManUnit != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ManUnit);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, ManUnit);
        }

        // GET: api/GetManufacturingUnit
        [ResponseType(typeof(ManUnit))]
        public ManUnit GetManufacturingUnit(int? Pid)
        {
            var ManUnit = new ManufacturingUnit_CRUD().ManufacturingUnit_GetById(Pid);
            return ManUnit;
        }


        // POST: api/PostManufacturingUnit/
        [HttpPost]
        public HttpResponseMessage PostManufacturingUnit(ManUnit ManufactUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ManufacturingUnit_CRUD().ManufacturingUnit_Insert(ManufactUnit);
                    if (result != string.Empty)
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


        // PUT: api/PutManufacturingUnit
        [HttpPut]
        public HttpResponseMessage PutManufacturingUnit(ManUnit ManufactUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ManufacturingUnit_CRUD().ManufacturingUnit_Update(ManufactUnit);
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


        // DELETE: api/DeleteManufacturingUnit 
        [HttpDelete]
        public HttpResponseMessage DeleteManufacturingUnit(int Pid)
        {
            var result = new ManufacturingUnit_CRUD().ManufacturingUnit_GetById(Pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = Convert.ToInt16(new ManufacturingUnit_CRUD().ManufacturingUnit_Delete(Pid));
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
