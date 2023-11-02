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
    public class MenuController : Controller
    {
        // GET: Menu
        private QLTTEntities1 db = new QLTTEntities1();
        public ActionResult Menu()
        {
            var viewmodel = new MutipleData();

            var listLoai = db.LoaiThucUong.ToList() ;
            var listThucUong = db.ThucUong.ToList();

            List<Menus> listMenu = new List<Menus>();


            foreach (var i in listThucUong)
            {
                Menus nl = new Menus();
                nl.IdTU = i.IdTU;
                nl.TenTU = i.TenTU;
                nl.IdLoai =i.IdLoai;
                nl.TenLoai = listLoai.FirstOrDefault(c => c.IdLoai == i.IdLoai).TenLoai;
                nl.Gia = i.Gia;
                nl.Date_update = i.Date_update;
                listMenu.Add(nl);
            }
            viewmodel.meNus = listMenu;

            return View(viewmodel);
        }
        public ActionResult ThemTU()
        {
            var list = new MutipleData();
            //list.thucUongs = db.ThucUong.Include("LoaiThucUong");
            list.loaiThucUongs = db.LoaiThucUong.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult ThemTU(ThucUong tu)
        {
            String Image = "";

            HttpPostedFileBase file = Request.Files["Image"];
            if (file != null && file.FileName != "")
            {
                String serverPath = HttpContext.Server.MapPath("~/assets/img/team");
                String filePath = serverPath + "/" + file.FileName;
                file.SaveAs(filePath);
                Image = file.FileName;
            }
            tu.Image = Image;
            db.ThucUong.Add(tu);
            db.SaveChanges();
            return RedirectToAction("Menu");

        }

        public ActionResult SuaTU(int id)
        {
            var viewmodel = new MutipleData();
            //viewmodel.thucUongs = db.ThucUong.Where(nl => nl.IdTU == id).ToList();
            viewmodel.loaiThucUongs = db.LoaiThucUong.ToList();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult SuaTU(ThucUong tu)
        {
            String Image = "";

            HttpPostedFileBase file = Request.Files["Image"];
            if (file != null && file.FileName != "")
            {
                String serverPath = HttpContext.Server.MapPath("~/assets/img/team");
                String filePath = serverPath + "/" + file.FileName;
                file.SaveAs(filePath);
                Image = file.FileName;
            }
            tu.Image = Image;
            db.Entry(tu).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Menu");
        }
        [HttpPost]
        public ActionResult XoaTU(int id)
        {

            ThucUong tu = db.ThucUong.Find(id);
            db.ThucUong.Remove(tu);
            db.SaveChanges();
            return RedirectToAction("Menu");
        }
    }
}
