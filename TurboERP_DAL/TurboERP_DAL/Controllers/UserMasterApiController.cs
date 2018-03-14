using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class UserMasterApiController : ApiController
    {
        private TurboEMSEntities db = new TurboEMSEntities();

        // GET: api/UserMaster
        public IEnumerable<Usermast> GetUserMasterdList()
        {
            var result = (from userMaster in db.Usermasts select userMaster).ToList();
            return result;
        }
        // GET: api/UserMaster
        public IEnumerable<Usermast> GetUserMasterdListByUserGroupId(int ugPid)
        {
            var result = (from userMaster in db.Usermasts where userMaster.Ug_Pid==ugPid select userMaster).ToList();
            return result;
        }
        
        // GET: api/UserMaster/5
        [ResponseType(typeof(Usermast))]
        public async Task<Usermast> GetUsermast(int id)
        {
            Usermast usermast = await db.Usermasts.FindAsync(id);
            if (usermast == null)
            {
                return null;
            }
            return usermast;
        }
        // PUT: api/UserMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsermast(int id, Usermast usermast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usermast.Pid)
            {
                return BadRequest();
            }

            db.Entry(usermast).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsermastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserMaster
        [ResponseType(typeof(Usermast))]
        public async Task<IHttpActionResult> PostUsermast(Usermast usermast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Usermasts.Add(usermast);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = usermast.Pid }, usermast);
        }
        

        // DELETE: api/UserMaster/5
        [ResponseType(typeof(Usermast))]
        public async Task<IHttpActionResult> DeleteUsermast(int id)
        {
            Usermast usermast = await db.Usermasts.FindAsync(id);
            if (usermast == null)
            {
                return NotFound();
            }

            db.Usermasts.Remove(usermast);
            await db.SaveChangesAsync();

            return Ok(usermast);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsermastExists(int id)
        {
            return db.Usermasts.Count(e => e.Pid == id) > 0;
        }
    }
}