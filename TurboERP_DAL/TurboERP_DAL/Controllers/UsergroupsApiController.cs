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
    public class UsergroupsApiController : ApiController
    {
        private TurboEMSEntities db = new TurboEMSEntities();

        // GET: api/Usergroups
        public IEnumerable<Usergroup> GetUsergroup()
        {
            var result = (from usergroup in db.Usergroups select usergroup).ToList();
            return result;
        }
        
        // GET: api/Usergroups/5
        [ResponseType(typeof(Usergroup))]
        public async Task<Usergroup> GetUsergroup(int id)
        {
            Usergroup usergroup = await db.Usergroups.FindAsync(id);
            if (usergroup == null)
            {
                return null;
            }

            return usergroup;
        }

        // PUT: api/Usergroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsergroup(int id, Usergroup usergroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usergroup.Pid)
            {
                return BadRequest();
            }

            db.Entry(usergroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsergroupExists(id))
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

        // POST: api/Usergroups
        [ResponseType(typeof(Usergroup))]
        public async Task<IHttpActionResult> PostUsergroup(Usergroup usergroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usergroups.Add(usergroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usergroup.Pid }, usergroup);
        }

        // DELETE: api/Usergroups/5
        [ResponseType(typeof(Usergroup))]
        public async Task<IHttpActionResult> DeleteUsergroup(int id)
        {
            Usergroup usergroup = await db.Usergroups.FindAsync(id);
            if (usergroup == null)
            {
                return NotFound();
            }

            db.Usergroups.Remove(usergroup);
            await db.SaveChangesAsync();

            return Ok(usergroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsergroupExists(int id)
        {
            return db.Usergroups.Count(e => e.Pid == id) > 0;
        }
    }
}