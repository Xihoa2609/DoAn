using Newtonsoft.Json;
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
    public class CTPNController : Controller
    {
        // GET: CTPN
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: CTPN
        public ActionResult CTPN(int id)
        {
            var list = new MutipleData();
            var listNL = db.NguyenLieu.ToList();
            var listNCC = db.NhaCungCap.ToList();
            var listCTPN = db.ChiTietPhieuNhap.Where(c => c.IdPN == id).ToList();
            List<ChiTietPhieuNhaps> ListCTPN = new List<ChiTietPhieuNhaps>();

            foreach (var i in listCTPN)
            {
                ChiTietPhieuNhaps ctpn = new ChiTietPhieuNhaps();
                ctpn.IdCTPN = i.IdCTPN;
                ctpn.IdPN = i.IdPN;
                ctpn.IdNL = i.IdNL;
                ctpn.TenNL = listNL.FirstOrDefault(c => c.IdNL == i.IdNL).TenNL == null ? "": listNL.FirstOrDefault(c => c.IdNL == i.IdNL).TenNL;
                ctpn.TenNhaCC = listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC == null ? "": listNCC.FirstOrDefault(c => c.IdNhaCC == i.IdNhaCC).TenNhaCC;
                ctpn.HanSuDung = i.HanSuDung;
                ctpn.SoLuong = i.SoLuong;
                ctpn.GiaNhap = i.GiaNhap;
                ctpn.ThanhTien = i.ThanhTien;
                ListCTPN.Add(ctpn);
            }

            list.chiTietPhieuNhaps = ListCTPN.ToList();
            return View(list);
        }
        public ActionResult ThemCTPN(int id)
        {
            var list = new MutipleData();

            list.phieuNhaps = db.PhieuNhap.Where(c => c.IdPN == id).ToList();
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
            list.nhaCungCap = db.NhaCungCap.ToList();
            var listCTPN = db.ChiTietPhieuNhap.Where(c =>c.IdPN == id).ToList();
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
        public ActionResult ThemCTPN(List<ChiTietPhieuNhap> listctpn)
        {
            var idpn = listctpn[0].IdPN;
            var listCTPN = db.ChiTietPhieuNhap.Where(c => c.IdPN == (int)idpn).ToList();
            double tongtien = 0;
            foreach (var i in listCTPN)
            {
                tongtien += (double)i.ThanhTien;
            }

            foreach (var i in listctpn)
            {
                tongtien += (double) i.ThanhTien;
            }
            var pn = db.PhieuNhap.Where(c => c.IdPN == (int)idpn).FirstOrDefault();
            pn.TongTien =(decimal) tongtien;
            pn.TinhTrang = "Chưa Duyệt";
            db.ChiTietPhieuNhap.AddRange(listctpn);
            db.SaveChanges();
            bool isSuccess = true; // Giả sử giá trị thành công là true

            return Json(new { success = isSuccess, message = "Hoàn thành phương thức thành công." }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult SuaCTPN(int id)
        {
            var viewmodel = new MutipleData();

            var listCTPN = db.ChiTietPhieuNhap.Where(ctpn => ctpn.IdCTPN == id).ToList();
            List<ChiTietPhieuNhaps> ListCTPN = new List<ChiTietPhieuNhaps>();
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

            viewmodel.chiTietPhieuNhaps = ListCTPN.ToList();
            viewmodel.nguyenLieus = listNL.ToList();
            viewmodel.nhaCungCap = db.NhaCungCap.ToList();

            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult SuaCTPN(ChiTietPhieuNhap ctpn)
        {
            db.Entry(ctpn).State = System.Data.Entity.EntityState.Modified;
            var pnTemp = db.ChiTietPhieuNhap.Where(c => c.IdCTPN == ctpn.IdCTPN && c.IdPN == ctpn.IdPN).FirstOrDefault();
            pnTemp.IdNL = ctpn.IdNL;
            pnTemp.IdNhaCC = ctpn.IdNhaCC;
            pnTemp.IdPN = ctpn.IdPN;
            pnTemp.HanSuDung = ctpn.HanSuDung;
            pnTemp.GiaNhap = ctpn.GiaNhap;
            pnTemp.SoLuong = ctpn.SoLuong;
            pnTemp.ThanhTien = ctpn.ThanhTien;
            db.SaveChanges();
            List<ChiTietPhieuNhap> listctpn = db.ChiTietPhieuNhap.Where(c => c.IdPN == ctpn.IdPN).ToList();
            
            double tongtien = 0;
            foreach (var i in listctpn)
            {
                tongtien += (double)i.ThanhTien;
            }
            var pn = db.PhieuNhap.Where(c => c.IdPN == (int)ctpn.IdPN).FirstOrDefault();
            pn.TongTien = (decimal)tongtien;
            pn.TinhTrang = "good";

            db.SaveChanges();
            return RedirectToAction("CTPN/" + ctpn.IdPN);
        }
        public ActionResult XoaCTPN(int id)
        {
            ChiTietPhieuNhap ctpn = db.ChiTietPhieuNhap.Find(id);
            var tempNL = db.NguyenLieu.Where(c => c.IdNL == ctpn.IdNL && c.IdNhaCC == ctpn.IdNhaCC).ToList();
            db.ChiTietPhieuNhap.Remove(ctpn);
            db.SaveChanges();

            List<ChiTietPhieuNhap> listctpn = db.ChiTietPhieuNhap.Where(c => c.IdPN == ctpn.IdPN).ToList();

            double tongtien = 0;
            foreach (var i in listctpn)
            {
                tongtien += (double)i.ThanhTien;
            }
            var pn = db.PhieuNhap.Where(c => c.IdPN == (int)ctpn.IdPN).FirstOrDefault();
            pn.TongTien = (decimal)tongtien;
            pn.TinhTrang = "good";
            db.SaveChanges();
            return RedirectToAction("CTPN");
        }

    }
}