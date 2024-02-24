using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        DbDevFolioEntities7 db = new DbDevFolioEntities7();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarPartial() {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
      
    }
}