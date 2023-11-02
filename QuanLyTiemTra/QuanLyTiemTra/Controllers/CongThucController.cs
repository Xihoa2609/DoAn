using Newtonsoft.Json;
using QuanLyTiemTra.Models;
using QuanLyTiemTra.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class CongThucController : Controller
    {
        // GET: NguyenLieu
        private QLTTEntities1 db = new QLTTEntities1();

        public ActionResult CongThuc(int id)
        {
            var list = new MutipleData();
            var listCongThuc = db.CongThuc.Where(c => c.IdTU == id).ToList();
            var listNguyenLieu = db.NguyenLieu.ToList();
            var listSize = db.Size.ToList();
            var listThucUong = db.ThucUong.ToList();

            List<CongThucs> listCongThucs = new List<CongThucs>();

            foreach(var i in listCongThuc)
            {
                CongThucs ct = new CongThucs();
                ct.IdNLTU = i.IdNLTU; 
                ct.IdTU = i.IdTU;
                ct.TenTU = listThucUong.FirstOrDefault(c => c.IdTU == i.IdTU).TenTU;
                ct.IdNL = i.IdNL;
                ct.tenNl = listNguyenLieu.FirstOrDefault(c => c.IdNL == i.IdNL).TenNL;
                ct.SoLuong = i.SoLuong;
                ct.DonVi = i.DonVi;
                ct.IdSize = i.IdSize;
                ct.tenSize = listSize.FirstOrDefault(c => c.IdSize == i.IdSize).Size1;
                listCongThucs.Add(ct);
            }
  
            list.congThucs = listCongThucs;
             
            return View(list);
        }
        public ActionResult ThemCT(int id)
        {
            var list = new MutipleData();

            list.phieuNhaps = db.PhieuNhap.Where(c => c.IdPN == id).ToList();
            var listNguyenLieu = db.NguyenLieu.ToList();
            var listNCC = db.NhaCungCap.ToList();
            var listSize = db.Size.ToList();

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
            list.sizes = listSize;

            list.nhaCungCap = db.NhaCungCap.ToList();
            var listCTPN = db.ChiTietPhieuNhap.Where(c => c.IdPN == id).ToList();
            List<ChiTietPhieuNhaps> ListCTPN = new List<ChiTietPhieuNhaps>();

            foreach (var i in listCTPN)
            {
                ChiTietPhieuNhaps ctpn = new ChiTietPhieuNhaps();
                ctpn.IdCTPN = i.IdCTPN;
                ctpn.IdPN = i.IdPN;
                ctpn.IdNL = i.IdNL;
                ctpn.TenNL = listNL.FirstOrDefault(c => c.IdNL == i.IdNL).TenNL;
                ctpn.TenNhaCC = listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC;
                ctpn.HanSuDung = i.HanSuDung;
                ctpn.SoLuong = i.SoLuong;
                ctpn.GiaNhap = i.GiaNhap;
                ctpn.ThanhTien = i.ThanhTien;
                ListCTPN.Add(ctpn);
            }

            list.chiTietPhieuNhaps = ListCTPN.ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            ViewBag.MultipleDataJson = JsonConvert.SerializeObject(list, settings);

            return View(list);
        }
        [HttpPost]
        public ActionResult ThemCT(List<CongThuc> listct)
        {

            db.CongThuc.AddRange(listct);
            db.SaveChanges();
            bool isSuccess = true;
            return Json(new { success = isSuccess, message = "Hoàn thành phương thức thành công." }, JsonRequestBehavior.AllowGet);
            

        }

        public ActionResult SuaCT(int id)
        {
            var viewmodel = new MutipleData();

            //viewmodel.thucUongs = db.ThucUong.ToList();
            //viewmodel.nguyenLieus = db.NguyenLieu.ToList();
            viewmodel.sizes = db.Size.ToList();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult SuaCT(CongThuc ct)
        {

            db.Entry(ct).State = System.Data.Entity.EntityState.Modified;
            var ctTemp = db.CongThuc.Where(c =>  c.IdNLTU == ct.IdNLTU && c.IdTU == ct.IdTU).FirstOrDefault();
            ctTemp.IdNL = ct.IdNL;
            ctTemp.IdTU = ct.IdTU;
            ctTemp.SoLuong = ct.SoLuong;
            ctTemp.DonVi = ct.DonVi;
            ctTemp.IdSize = ct.IdSize;
            db.SaveChanges();
            return RedirectToAction("CongThuc/" +ct.IdNLTU);
        }
        [HttpPost]
        public ActionResult XoaCT(int id)
        {

            CongThuc ct = db.CongThuc.Find(id);
            var tempCT = db.NguyenLieu.Where(c => c.IdNL == ct.IdNL).ToList();
            db.CongThuc.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("CongThuc");
        }
    }
}
