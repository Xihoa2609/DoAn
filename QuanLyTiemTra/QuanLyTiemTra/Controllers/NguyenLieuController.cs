using QuanLyTiemTra.Models;
using QuanLyTiemTra.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;

namespace QuanLyTiemTra.Controllers
{
    public class NguyenLieuController : Controller
    {
        // GET: NguyenLieu
        private QLTTEntities1 db = new QLTTEntities1();
        public ActionResult NguyenLieu()
        {
            var list = new MutipleData();
            var listNguyenLieu = db.NguyenLieu.ToList();
            var listNCC = db.NhaCungCap.ToList();
            List<NguyenLieus> listNL = new List<NguyenLieus>(); 
            foreach(var i in listNguyenLieu)
            {
                NguyenLieus nl = new NguyenLieus();
                nl.IdNL = i.IdNL;
                nl.IdNhaCC = (int) i.IdNhaCC;
                nl.TenNL = i.TenNL;
                nl.DVT = i.DVT;
                nl.TonKho = (int)i.TonKho;
                nl.HanSuDung = (DateTime)i.HanSuDung;
                nl.TenNhaCC = listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC;
                listNL.Add(nl);
            }
            list.nguyenLieus = listNL;
            
            return View(list);
        }
        public ActionResult Them()
        {
            var list = new MutipleData();
            var listNguyenLieu = db.NguyenLieu.ToList();
            var listNCC = db.NhaCungCap.ToList();
            List<NguyenLieus> listNL = new List<NguyenLieus>();
            foreach (var i in listNguyenLieu)
            {
                NguyenLieus nl = new NguyenLieus();
                nl.IdNL = i.IdNL;
                nl.IdNhaCC = (int)i.IdNhaCC;
                nl.TenNL = i.TenNL;
                nl.DVT = i.DVT;
                nl.TonKho = (int)i.TonKho;
                nl.HanSuDung = (DateTime)i.HanSuDung;
                nl.TenNhaCC = listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC;
                listNL.Add(nl);
            }
            list.nguyenLieus = listNL;
            list.nhaCungCap = listNCC;
            return View(list);
        }
        [HttpPost]
        public ActionResult Them(NguyenLieu nl)
        {

            db.NguyenLieu.Add(nl);
            db.SaveChanges();
            return RedirectToAction("NguyenLieu");

        }

        public ActionResult Sua(int id)
        {
            var viewmodel = new MutipleData();
            {
                var list = new MutipleData();
                var listNguyenLieu = db.NguyenLieu.Where(nl => nl.IdNL == id).ToList();
                var listNCC = db.NhaCungCap.ToList();
                List<NguyenLieus> listNL = new List<NguyenLieus>();
                foreach (var i in listNguyenLieu)
                {
                    NguyenLieus nl = new NguyenLieus();
                    nl.IdNL = i.IdNL;
                    nl.IdNhaCC = (int)i.IdNhaCC;
                    nl.TenNL = i.TenNL;
                    nl.DVT = i.DVT;
                    nl.TonKho = (int)i.TonKho;
                    nl.HanSuDung = (DateTime)i.HanSuDung;
                    nl.TenNhaCC = listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC;
                    listNL.Add(nl);
                }
                list.nguyenLieus = listNL;
                list.nhaCungCap = listNCC;
                return View(list);
            }
        }
        [HttpPost]
        public ActionResult Sua(NguyenLieu ngl)
        {

            db.Entry(ngl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("NguyenLieu");
        }
        [HttpPost]
        public ActionResult Xoa(int id)
        {

            NguyenLieu ngl = db.NguyenLieu.Find(id);
            db.NguyenLieu.Remove(ngl);
            db.SaveChanges();
            return RedirectToAction("NguyenLieu");
        }
    }
}
