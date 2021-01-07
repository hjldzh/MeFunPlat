using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;
using Newtonsoft.Json;

namespace UI.Areas.SystemArea.Controllers
{
    public class RoleManagerController : Controller
    {
        // GET: SystemArea/RoleManager
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            string JsonStr = "{\"code\": 0,\"msg\": \"\",\"count\": 1000,\"data\": ";
            List<SysRoles> anlist = new List<SysRoles>();
            using (MyContext context = new MyContext())
            {
                anlist = context.SysRoles.Where(x => x.RoleState == 0).ToList();
            }
            string strJson = JsonConvert.SerializeObject(anlist);
            JsonStr += strJson + "}";
            return Content(JsonStr);

        }
    }
}