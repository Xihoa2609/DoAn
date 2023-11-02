using QuanLyTiemTra.Models;
using QuanLyTiemTra.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class LoaiController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: NhanVien
        public ActionResult Loai()
        {
            List<LoaiThucUong> list = new List<LoaiThucUong>();
            list = db.LoaiThucUong.ToList();
            return View(list);
        }

        public ActionResult ThemLoai()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ThemLoai(LoaiThucUong nl)
        {
            db.LoaiThucUong.Add(nl);
            db.SaveChanges();
            return RedirectToAction("Loai");
        }

        public ActionResult SuaLoai(int id)
        {
            LoaiThucUong nl = db.LoaiThucUong.Where(c => c.IdLoai == id).FirstOrDefault();
            return View(nl);
        }
        [HttpPost]
        public ActionResult SuaLoai(LoaiThucUong nl)
        {
            db.Entry(nl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Loai");
        }
        [HttpPost]
        public ActionResult XoaLoai(int id)
        {
            LoaiThucUong nl = db.LoaiThucUong.Where(c => c.IdLoai == id).FirstOrDefault();
            db.LoaiThucUong.Remove(nl);
            db.SaveChanges();
            return RedirectToAction("Loai");
        }
    }
}