using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AdminController : Controller
    {
        DbDevFolioEntities6 db = new DbDevFolioEntities6();
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(TblAdmin p)
        {
            var values = db.TblAdmin.Find(1);

            if ("ezelhan" == values.Username && "1234" == values.Password)
            {
                return RedirectToAction("AboutList", "About");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
    }
}