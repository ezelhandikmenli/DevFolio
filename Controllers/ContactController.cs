﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities7 db = new DbDevFolioEntities7();
        [HttpGet] 
        public ActionResult ContactInfo()
        {
            var values = db.TblAddress.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            p.IsRead = false;
            p.SendMessageDate = DateTime.Now;
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
       [HttpGet]
       public ActionResult MessageRead(TblContact p)
        {
            var values = db.TblContact.Find(p.IsRead);
            return View(values);

        }
        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        
        }
    }
}