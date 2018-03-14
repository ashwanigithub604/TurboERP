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
    public class UserGroupModuleApiController : ApiController
    {
        private TurboEMSEntities db = new TurboEMSEntities();

        // GET: api/UserGroupModule
        public IEnumerable<UserGroupRight> GetUsergroupmodByCode(string userGroupCode)
        {
            var result = (from usergroupmod in db.UserGroupRights where usergroupmod.Usergrp_Code == userGroupCode select usergroupmod).ToList();
            return result;
        }

        // GET: api/UserGroupModule/5
        [ResponseType(typeof(UserGroupRight))]
        public async Task<IHttpActionResult> GetUsergroupmod(int id)
        {
            UserGroupRight usergroupmod = await db.UserGroupRights.FindAsync(id);
            if (usergroupmod == null)
            {
                return NotFound();
            }

            return Ok(usergroupmod);
        }

        // PUT: api/UserGroupModule/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsergroupmod(int id, UserGroupRight usergroupmod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usergroupmod.PID)
            {
                return BadRequest();
            }

            db.Entry(usergroupmod).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsergroupmodExists(id))
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

        // POST: api/UserGroupModule
        [ResponseType(typeof(UserGroupRight))]
        public async Task<IHttpActionResult> PostUsergroupmod(UserGroupRight usergroupmod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserGroupRights.Add(usergroupmod);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usergroupmod.PID }, usergroupmod);
        }
        public async Task<IHttpActionResult> PostAllUsergroupmod(List<UserGroupRight> usergroupmodList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserGroupRights.AddRange(usergroupmodList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usergroupmodList[0].PID }, usergroupmodList);

        }
        // DELETE: api/UserGroupModule/5
        [ResponseType(typeof(UserGroupRight))]
        public async Task<IHttpActionResult> DeleteUsergroupmod(int id)
        {
            UserGroupRight usergroupmod = await db.UserGroupRights.FindAsync(id);
            if (usergroupmod == null)
            {
                return NotFound();
            }

            db.UserGroupRights.Remove(usergroupmod);
            await db.SaveChangesAsync();

            return Ok(usergroupmod);
        }

        // DELETE: api/DeleteUsergroupmodByUserGrpCode/5
        [ResponseType(typeof(UserGroupRight))]
        public async Task<IHttpActionResult> DeleteUsergroupmodByUserGrpCode(string userGrpCode)
        {
            List<UserGroupRight> usergroupmod = await db.UserGroupRights.Where(a=>a.Usergrp_Code==userGrpCode).ToListAsync();
            if (usergroupmod == null)
            {
                return NotFound();
            }

            db.UserGroupRights.RemoveRange(usergroupmod);
            await db.SaveChangesAsync();

            return Ok(usergroupmod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsergroupmodExists(int id)
        {
            return db.UserGroupRights.Count(e => e.PID == id) > 0;
        }
    }
}