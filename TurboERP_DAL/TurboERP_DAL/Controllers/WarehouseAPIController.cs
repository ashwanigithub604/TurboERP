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
    public class WarehouseAPIController : ApiController
    {
        [Route("WareHouse")]
        public HttpResponseMessage GetWareHouse()
        {
            var WareHouse = new  WareHouse().WareHouse_GetAll();
            if (WareHouse != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, WareHouse);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, WareHouse);
        }

        [HttpGet]        
        public HttpResponseMessage GetCompList()
        {
             var dt=new WareHouse().GetComp();
              return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET: api/GetUnit/2
        [ResponseType(typeof(Warehousemast))]
        public Warehousemast GetWareHouse(int? Pid)
        {
            var WareHouse = new WareHouse().WareHouse_GetById(Pid);
            return WareHouse;
        }

        // POST: api/PostUnit/
        [HttpPost]
        public HttpResponseMessage PostWareHouse(Warehousemast WareHouse)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new WareHouse().WareHouse_Insert(WareHouse);

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
        public HttpResponseMessage PutWareHouse(Warehousemast WareHouse)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new WareHouse().WareHouse_Update(WareHouse);

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
        public HttpResponseMessage DeleteWarehouse(int Pid)
        {
            var result = new WareHouse().WareHouse_GetById(Pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = new WareHouse().WareHouse_Delete(Pid);
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
