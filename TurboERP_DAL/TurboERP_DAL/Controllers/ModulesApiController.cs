using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    public class ModulesApiController : ApiController
    {
        private TurboEMSEntities db = new TurboEMSEntities();

        // GET: api/Modules
        public ModulesApiController()
        {

        }
        public IEnumerable<Module> GetModules()
        {
            var result = (from module in db.Modules select module).ToList();
            return result;
        }
        public IEnumerable<Module> GetMenu(string id)
        {
            var result = (from module in db.Modules join usermo in  db.UserRights  on module.Mod_Code equals usermo.Mod_Code where usermo.User_Code== id
                          select module).ToList();
            return result;
        }
        
        // GET: api/Modules/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> GetModules(int id)
        {
            Module modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }

            return Ok(modules);
        }

        // PUT: api/Modules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModules(int id, Module modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modules.PID)
            {
                return BadRequest();
            }

            db.Entry(modules).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulesExists(id))
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

        // POST: api/Modules
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> PostModules(Module modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modules.Add(modules);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModulesExists(modules.PID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = modules.PID }, modules);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> DeleteModules(int id)
        {
            Module modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }

            db.Modules.Remove(modules);
            await db.SaveChangesAsync();

            return Ok(modules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModulesExists(int id)
        {
            return db.Modules.Count(e => e.PID == id) > 0;
        }

        public HttpResponseMessage GetMenu()
        {
            var moduleListWithActions = new List<MGroupModuleList>();
            //if (HttpContext.Current.Session["Code"].ToString() != null)
            //{
            //    string Code = Convert.ToString(HttpContext.Current.Session["Code"]);
            //}
            
            string Code1 = "A000000";
            var moduleList = new ModulesApiController().GetMenu(Code1);
            foreach (var module in moduleList)
            {
                var moduleData = moduleListWithActions.Where(a => a.Grp_Code == module.Grp_Code).FirstOrDefault();
                if (moduleData != null)
                {
                    var modules = moduleData.Modules.Where(a => a.Mod_Code == module.Mod_Code).FirstOrDefault();
                    if (modules != null)
                    {
                        var action = new ActionList { Action = module.Action, IsSelected = false };
                        modules.Actions.Add(action);
                        var subModule = modules.SubModuleList.Where(a => a.SubMenu == module.SubMenu).FirstOrDefault();
                        if (subModule != null)
                        {
                            subModule.Actions.Add(action);

                        }
                        else if (module.SubMenu != null)
                        {
                            modules.SubModuleList.Add(new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { action }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName });
                        }
                    }
                    else
                    {
                        var subModuleList = module.SubMenu != null ? new List<SubModuleList>() { new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName } } : new List<SubModuleList>();
                        modules = new MenuModuleList { Mod_Code = module.Mod_Code, Menu_Desc = module.Menu_Desc, Mod_Name = module.Mod_Code, ControllerName = module.ControllerName, ActionName = module.ActionName, SubModuleList = subModuleList, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false };
                        moduleData.Modules.Add(modules);

                    }
                }
                else
                {


                    moduleData = new MGroupModuleList();
                    moduleData.Grp_Code = module.Grp_Code;
                    moduleData.Grp_Desc = module.Grp_Desc;
                    if (module.Mod_Code == module.Grp_Code) { moduleData.treeview = "treeview"; moduleData.treeviewmenu = "treeview-menu"; }
                    if (module.Active == true) { moduleData.arrow = "fa fa-angle-left pull-right"; moduleData.hrefurl = "#"; } else { moduleData.arrow = ""; moduleData.hrefurl = "../Account/Home"; }


                    var subModuleList = module.SubMenu != null ? new List<SubModuleList>() { new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName } } : new List<SubModuleList>();

                    moduleData.Modules = new List<MenuModuleList>() { new MenuModuleList { Mod_Code = module.Mod_Code, Menu_Desc = module.Menu_Desc, Mod_Name = module.Mod_Code, ControllerName = module.ControllerName, ActionName = module.ActionName, SubModuleList = subModuleList, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false } };
                    moduleListWithActions.Add(moduleData);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, moduleListWithActions);
           
        }
    }
}