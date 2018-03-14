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
    public class UserModuleApiController : ApiController
    {
        private TurboEMSEntities db = new TurboEMSEntities();

        // GET: api/UserModule
       
        public IEnumerable<UserRight> GetUsermodByUserCode(string userCode)
        {
            var result = (from usermod in db.UserRights where usermod.User_Code == userCode select usermod).ToList();
            return result;
        }

        // GET: api/UserModule/5
        [ResponseType(typeof(UserRight))]
        public async Task<IHttpActionResult> GetUsermod(int id)
        {
            UserRight usermod = await db.UserRights.FindAsync(id);
            if (usermod == null)
            {
                return NotFound();
            }

            return Ok(usermod);
        }

        // PUT: api/UserModule/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsermod(int id, UserRight usermod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usermod.PID)
            {
                return BadRequest();
            }

            db.Entry(usermod).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsermodExists(id))
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

        // POST: api/UserModule
        [ResponseType(typeof(UserRight))]
        public async Task<IHttpActionResult> PostUsermod(UserRight usermod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserRights.Add(usermod);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usermod.PID }, usermod);
        }

        // DELETE: api/UserModule/5
        [ResponseType(typeof(UserRight))]
        public async Task<IHttpActionResult> DeleteUsermod(int id)
        {
            UserRight usermod = await db.UserRights.FindAsync(id);
            if (usermod == null)
            {
                return NotFound();
            }

            db.UserRights.Remove(usermod);
            await db.SaveChangesAsync();

            return Ok(usermod);
        }
        public async Task<IHttpActionResult> DeleteUsermodByUserCode(string usercode)
        {
            List<UserRight> usermod = await db.UserRights.Where(a=>a.User_Code==usercode).ToListAsync();
            if (usermod.Count == 0)
            {
                return NotFound();
            }

            db.UserRights.RemoveRange(usermod);
            await db.SaveChangesAsync();

            return Ok(usermod);

        }
        public async void SaveUserModule(int ug_pid, string userCode)
        {
            var ugmodules = (from ugmod in db.UserGroupRights
                             join userGroup in db.Usergroups on ugmod.Usergrp_Code equals userGroup.Usergroup_Code
                             where userGroup.Pid == ug_pid
                             select ugmod).ToList();
            if (ugmodules.Any())
            {
                var userModList = ugmodules.Select(a => new UserRight
                {
                    User_Code = userCode,
                    Mod_Code = a.Mod_Code,
                    AddNew = a.Add_new,
                    Edit = a.Edit,
                    Print = a.Print,
                    Delete = a.Delete,
                    Assign = a.Assign,
                    View = a.View

                }).ToList();
                db.UserRights.AddRange(userModList);
                await db.SaveChangesAsync();
            }
        }
        public async Task<IHttpActionResult> DeleteAllUsermodByUserCodeList(List<string> usercodeList)
        {
            List<UserRight> usermod = await db.UserRights.Where(a => usercodeList.Contains(a.User_Code)).ToListAsync();
            if (usermod.Count == 0)
            {
                return NotFound();
            }

            db.UserRights.RemoveRange(usermod);
            await db.SaveChangesAsync();

            return Ok(usermod);

        }
        
        public async Task<IHttpActionResult> PostAllUsermod(List<UserRight> usermodList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserRights.AddRange(usermodList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usermodList[0].PID }, usermodList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsermodExists(int id)
        {
            return db.UserRights.Count(e => e.PID == id) > 0;
        }
    }
}