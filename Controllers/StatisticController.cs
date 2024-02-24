using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities7 db = new DbDevFolioEntities7();


        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.lastServiceTitleName = db.GetLastServiceTitle().FirstOrDefault();
            ViewBag.FirstProject = db.TblProject.OrderBy(x => x.ProjectID).FirstOrDefault().Title;
            ViewBag.SocialCount = db.TblSocialMedia.Count();
            ViewBag.CategoryFirst = db.TblCategory.OrderBy(x => x.CategoryId).FirstOrDefault().CategoryName;
            return View();
        }
    }
}