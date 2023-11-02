﻿using QuanLyTiemTra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class NhaCCController : Controller
    {
        // GET: NhaCC
        private QLTTEntities1 db = new QLTTEntities1();
      
       public ActionResult NhaCC()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            list = db.NhaCungCap.ToList();
            return View(list);
        }

        public ActionResult ThemNCC()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ThemNCC(NhaCungCap ncc)
        {
            db.NhaCungCap.Add(ncc);
            db.SaveChanges();
            return RedirectToAction("NhaCC");
        }

        public ActionResult SuaNCC(int id)
        {
            NhaCungCap ncc  = db.NhaCungCap.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult SuaNCC(NhaCungCap ncc)
        {
            db.Entry(ncc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("NhaCC");
        }
        [HttpPost]
        public ActionResult XoaNCC(int id)
        {
            NhaCungCap ncc = db.NhaCungCap.Find(id);
            db.NhaCungCap.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("NhaCC");
        }
    }
}