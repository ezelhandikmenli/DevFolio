using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio2.Controllers
{
    public class ServiceController : Controller
    {
        DbDevFolioEntities6 db = new DbDevFolioEntities6();
        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService s)
        {
            db.TblService.Add(s);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateService(TblService s)
        {
            var value = db.TblService.Find(s.ServiceID);
            value.ServiceTitle = s.ServiceTitle;
            value.Desciption = s.Desciption;
            value.ServiceImageUrl = s.ServiceImageUrl;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}