using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        DbDevFolioEntities7 db = new DbDevFolioEntities7();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialServices()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
       
        public PartialViewResult PartialStatistic()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            return PartialView();
        }
        public PartialViewResult PartialPortfolio()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        
        public PartialViewResult PartialReference()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        
       
        [HttpGet]
        public PartialViewResult PartialSendMessage()
        {
            ViewBag.show = false;
            TblContact emptyModel = new TblContact(); 
            return PartialView(emptyModel);
        }
        
        [HttpPost]
        public PartialViewResult PartialSendMessage(TblContact p)
        {
            p.IsRead = false;
            p.SendMessageDate = DateTime.Now;
            db.TblContact.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.show = true;
            return PartialView("PartialSendMessage");
        }

        public PartialViewResult PartialAddress()
        {
            var values = db.TblAddress.ToList();
            return PartialView(values);
        }

    }
}