﻿using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities6 db = new DbDevFolioEntities6();


        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            return View();
        }
    }
}