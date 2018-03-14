using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TurboERP_DAL.App_DAL;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class CountryMastApiController : ApiController
    {
        
        [Route("CountryMast")]
        public HttpResponseMessage GetCountry()
        {
            var country = new Country_Crud().Country_GetAll();
            if (country != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, country);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, country);
        }

        // GET: api/GetCountry
        [ResponseType(typeof(Country))]
        public Country GetCountry(int? Pid)
        {
            var country = new Country_Crud().Country_GetById(Pid);
            return country;
        }


        [HttpGet]
        public HttpResponseMessage GetContinentalCode()
        {
            var continent = new Country_Crud().ContinentalCode();
            return Request.CreateResponse(HttpStatusCode.OK, continent);
        }

        // POST: api/PostCountry/
        [HttpPost]
        public HttpResponseMessage PostCountry(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = new Country_Crud().Country_Insert(country);

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

        // PUT: api/PutCountry
        [HttpPut]
        public HttpResponseMessage PutCountry(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new Country_Crud().Country_Update(country);
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

          


        // DELETE: api/DeleteCountry 
        [HttpDelete]
        public HttpResponseMessage DeleteCountryMast(int Pid)
        {
            var result = new Country_Crud().Country_GetById(Pid);
            if (result.PID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, result);
            }
            try
            {
                result.PID = Convert.ToInt16( new Country_Crud().Country_Delete(Pid));
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
