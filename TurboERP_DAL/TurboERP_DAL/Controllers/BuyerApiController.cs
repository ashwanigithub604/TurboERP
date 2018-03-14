using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurboERP_DAL.Models;
using TurboERP_DAL.App_DAL;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace TurboERP_DAL.Controllers
{
    public class BuyerApiController : ApiController
    {
       
        public BuyerApiController()
        {
           
        }
        // GET: api/GetBuyers/
        [Route("BuyersDetails")]
        public HttpResponseMessage GetBuyers()
        {
            var buyers = new Buyer_Crud().Buyer_GetAll();
            if(buyers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, buyers);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, buyers);
        }

        // GET: api/GetBuyer/2
        public Buyer GetBuyer(int? id)
        {
            var buyer = new Buyer_Crud().Buyer_GetById(id);
            return buyer;
        }

        // POST: api/PostBuyer/
        [HttpPost]
        public HttpResponseMessage PostBuyer(Buyer buyer)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new Buyer_Crud().Buyer_Insert(buyer);

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
        
        // PUT: api/PutBuyer/5
        [HttpPut]
        public HttpResponseMessage PutBuyer(Buyer buyer)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new Buyer_Crud().Buyer_Update(buyer);

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


        // DELETE: api/DeleteBuyer/5 
        [HttpDelete]
        public HttpResponseMessage DeleteBuyer(int Pid)
        {
            var result = new Buyer_Crud().Buyer_GetById(Pid);
            if (result.Pid == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent,result);
            }
            try
            {
                result.Pid = new Buyer_Crud().Buyer_Delete(Pid);
                if (result.Pid != 0)
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
