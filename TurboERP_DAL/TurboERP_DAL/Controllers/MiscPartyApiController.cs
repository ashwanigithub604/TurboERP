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
    public class MiscPartyApiController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetpartyType()
        {
            try
            {
                var partyTypeDt = new MiscPartycls().GetpartyType();
                if (partyTypeDt != null)
                    return Request.CreateResponse(HttpStatusCode.OK, partyTypeDt);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, partyTypeDt);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        [HttpGet]
        [Route("MiscParty")]
        public HttpResponseMessage GetMiscPartyGrid()
        {
            try
            {
               var miscPartyDt = new MiscPartycls().MiscPartyGrid();
                if(miscPartyDt!=null)
                return Request.CreateResponse(HttpStatusCode.OK, miscPartyDt);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, miscPartyDt);
            }
            catch (Exception Ex)
            {
             return Request.CreateResponse(HttpStatusCode.BadRequest,Ex.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetMiscPartyById(int PID)
        {
            try
            {
                var miscPartyDt = new MiscPartycls().GetMiscPartyById(PID);
                if (miscPartyDt != null)
                    return Request.CreateResponse(HttpStatusCode.OK, miscPartyDt);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent, miscPartyDt);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage InsertMiscParty(MisPrty misPrty)
        {
            try
            {
               int result = new MiscPartycls().InsertMiscParty(misPrty);
                if (result==1)
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
        public HttpResponseMessage UpdateMiscParty(MisPrty misPrty)
        {
            try
            {
                    int result = new MiscPartycls().UpdateMiscParty(misPrty);
                    if (result==1)
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
        public HttpResponseMessage DeleteMiscParty(int PID)
        {
            try
            {
                int result = new MiscPartycls().DeleteMiscParty(PID);
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
