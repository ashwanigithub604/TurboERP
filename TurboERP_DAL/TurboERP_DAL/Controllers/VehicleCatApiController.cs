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
    public class VehicleCatApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetVehCats()
        {
            var vehCats = new VehCats().VehCat_GetAll();
            if (vehCats != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehCats);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, vehCats);
        }

        // GET: api/GetVehCat/2
        [ResponseType(typeof(VehiCat))]
        public VehiCat GetVehCat(int? Pid)
        {
            var vehCat = new VehCats().VehCat_GetById(Pid);
            return vehCat;
        }

        // POST: api/PostVehCat/
        [HttpPost]
        public HttpResponseMessage PostVehCat(VehiCat vehCat)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new VehCats().VehCat_Insert(vehCat);

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

        // PUT: api/PutVehCat/5
        [HttpPut]
        public HttpResponseMessage PutVehCat(VehiCat vehCat)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new VehCats().VehCat_Update(vehCat);

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

        // DELETE: api/DeleteVehCat/5 
        [HttpDelete]
        public HttpResponseMessage DeleteVehCat(int Pid)
        {
            var result = new VehCats().VehCat_GetById(Pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = new VehCats().VehCat_Delete(Pid);
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
