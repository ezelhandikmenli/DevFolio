using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class CategoryController : Controller
    {
        DbDevFolioEntities6 db = new DbDevFolioEntities6();
        public ActionResult CategoryList()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateCategory(TblCategory p)
        {
            var values = db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory c)
        {
            var value = db.TblCategory.Find(c.CategoryId);
            value.CategoryId = c.CategoryId;
            value.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }


    }
}