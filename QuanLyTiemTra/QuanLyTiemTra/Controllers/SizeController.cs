using QuanLyTiemTra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class SizeController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: Size
        public ActionResult Size()
        {
            List<Size> list = new List<Size>();
            list = db.Size.ToList();    
            return View(list);
        }

        public ActionResult ThemSize()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ThemSize(Size s)
        {
            db.Size.Add(s);
            db.SaveChanges();
            return RedirectToAction("Size");
        }

        public ActionResult SuaSize(int id)
        {
            Size s = db.Size.Where( c => c.IdSize == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult SuaSize(Size s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Size");
        }
        [HttpPost]

        public ActionResult XoaSize(int id)
        {
            Size s = db.Size.Where(c => c.IdSize == id).FirstOrDefault();
            db.Size.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Size");
        }
    }
}