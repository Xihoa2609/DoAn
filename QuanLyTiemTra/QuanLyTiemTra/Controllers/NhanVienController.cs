using QuanLyTiemTra.Models;
using QuanLyTiemTra.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class NhanVienController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: NhanVien
        public ActionResult NhanVien()
        {
            List<Staff> list = new List<Staff>();
            list = db.Staff.ToList();
            return View(list);
        }

        public ActionResult ThemNV()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ThemNV(Staff nv)
        {
            db.Staff.Add(nv);
            db.SaveChanges();
            return RedirectToAction("NhanVien");
        }
        
        public ActionResult SuaNV(int id)
        {
            Staff nv = db.Staff.Where(c => c.IdStaff == id).FirstOrDefault();
            return View(nv);
        }
        [HttpPost]
        public ActionResult SuaNV(Staff nv)
        {
            db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("NhanVien");
        }
        [HttpPost]
        public ActionResult XoaNV(int id)
        {
            Staff nv = db.Staff.Where(c=> c.IdStaff == id).FirstOrDefault();
            db.Staff.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("NhanVien");
        }
    }
}