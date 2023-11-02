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
    public class PhieuNhapController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: PhieuNhap
        public ActionResult PhieuNhap()
        {
            List<PhieuNhap> list = new List<PhieuNhap>();
            list = db.PhieuNhap.ToList();
            return View(list);
        }
        public ActionResult ThemPN()
        {
            var viewmodel = new MutipleData();
            var listNguyenLieu = db.NguyenLieu.ToList();
            var listNCC = db.NhaCungCap.ToList();
            var listPN = db.PhieuNhap.ToList();
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
            
            viewmodel.nguyenLieus = listNL;
            viewmodel.nhaCungCap = listNCC;
            viewmodel.phieuNhaps = listPN;
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult ThemPN(PhieuNhap pn)
        {
            DateTime now = DateTime.Now;
            pn.NgayNhap = now;
            db.PhieuNhap.Add(pn);
            
            db.SaveChanges();
            return RedirectToAction("PhieuNhap");
        }
        public ActionResult SuaPN(int id)
        {
            var viewmodel = new MutipleData();
            {
                PhieuNhap listPhieuNhap = db.PhieuNhap.Where(pn => pn.IdPN == id).FirstOrDefault();

                return View(listPhieuNhap);
            }
            
           
        }
        [HttpPost]
        public ActionResult SuaPN(PhieuNhap pn)
        {
            db.Entry(pn).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PhieuNhap");
        }
        [HttpPost]
        public ActionResult XoaPN(int id)
        {
            PhieuNhap pn = db.PhieuNhap.Find(id);
            db.PhieuNhap.Remove(pn);
            db.SaveChanges();
            return RedirectToAction("PhieuNhap");
        }
        public ActionResult ThanhToan(int id)
        {
            var tempPN = db.PhieuNhap.Where(c => c.IdPN == id).ToList();
            if (tempPN.Count > 0)
            {
                tempPN[0].TinhTrang = "Da Duyet";
                var listCTPN = db.ChiTietPhieuNhap.Where(c => c.IdPN == id).ToList();
                foreach (var i in listCTPN)
                {
                    // tìm xem có nguyen liệu cùng vs nhà cc nếu có + dồn
                    var tempNL = db.NguyenLieu.Where(c => c.IdNL == i.IdNL && c.IdNhaCC == i.IdNhaCC && c.HanSuDung == i.HanSuDung).ToList();
                        
                    if (tempNL.Count > 0)
                    {
                        tempNL[0].TonKho += i.SoLuong;
                    }
                    else
                    {
                        //nếu k có nek thì tạo 1 cái nguyên liệu cũ vs nhà cc khác 
                        var tempNLnew = db.NguyenLieu.Where(c => c.IdNL == i.IdNL).FirstOrDefault();
                        NguyenLieu NL = new NguyenLieu();
                        NL.IdNL = tempNLnew.IdNL;
                        NL.TenNL = tempNLnew.TenNL;
                        NL.IdNhaCC = i.IdNhaCC;
                        NL.TonKho = i.SoLuong;
                        NL.HanSuDung = tempNLnew.HanSuDung;
                        NL.DVT = tempNLnew.DVT;
                        db.NguyenLieu.Add(NL);
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("PhieuNhap");
        }
    }
}