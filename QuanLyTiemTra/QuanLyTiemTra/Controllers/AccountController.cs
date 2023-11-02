using QuanLyTiemTra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemTra.Controllers
{
    public class AccountController : Controller
    {
        private QLTTEntities1 db = new QLTTEntities1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(Account acc)
        {
            var usr = db.Account.Where(a => a.Email.Equals(acc.Email) && a.Pass.Equals(acc.Pass)).FirstOrDefault();
            if (usr != null)
            {
                Session["Email"] = acc.Email.ToString();
                Session["Pass"] = acc.Pass.ToString();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", " Tên tài khoản hoặc mật khẩu sai! ");
            }
            return View();
        }
        public ActionResult Logout()
        {
            // Xóa session đăng nhập
            Session.Abandon();

            // Chuyển hướng đến trang chủ
            return RedirectToAction("DangNhap", "Account");
        }

    }
}