using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities6 db = new DbDevFolioEntities6();
        public ActionResult ProfileList()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult ProfileCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProfileCreate(TblProfile p)
        {
            var values = db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            return View(value);
        }
        [HttpPost] 
        public ActionResult UpdateProfile(TblProfile p)
        {
            var value = db.TblProfile.Find(p.ProfileId);
            value.NameSurname = p.NameSurname;
            value.Phone = p.Phone;
            value.Email = p.Email;
            value.Title =p.Title;
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

    }
}