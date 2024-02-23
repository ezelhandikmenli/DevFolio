using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class FeatureController : Controller
    {
        DbDevFolioEntities7 db = new DbDevFolioEntities7();
        public ActionResult FeatureList()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(TblFeature p)
        {
            var values = db.TblFeature.Add(p);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            db.TblFeature.Remove(values);
            db.SaveChanges();
            return RedirectToAction("FeatureList");

        }
        [HttpGet]
        public ActionResult UpdateFeature( int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature s)
        {
            var value = db.TblFeature.Find(s.FeatureId);
            value.HeaderTitle = s.HeaderTitle;
            value.HeaderDesciption = s.HeaderDesciption;
            db.SaveChanges();
            return RedirectToAction("Featurelist");

        }

    }
}