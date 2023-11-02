using QuanLyTiemTra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class CustomerController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1(); 
        // GET: Customer
        public ActionResult KhachHang()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult ThongTin()
        {
            return View();
        }
        public ActionResult ThemKH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemKH(Customer kh)
        {
            if (ModelState.IsValid)
            {
                
                
                db.Customer.Add(kh);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Đăng ký thành công!";

            }
            // Trả lại cùng view đăng ký tập thử
            return RedirectToAction("ThemKH");
        }
        public ActionResult ThemTV(Customer kh)
        {
          
            db.Customer.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
        public ActionResult SuaKH(int id)
        {
            Customer kh = db.Customer.Where(c => c.IdKH == id).FirstOrDefault();
            return View(kh);
        }
        [HttpPost]
        public ActionResult SuaKH(Customer kh)
        {
            //DateTime now = DateTime.Now;
            //tv.NgayTao = now;
            db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
        [HttpPost]
        public ActionResult XoaKH(int id)
        {
            Customer kh = db.Customer.Where(c => c.IdKH == id).FirstOrDefault();
            db.Customer.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
    }
