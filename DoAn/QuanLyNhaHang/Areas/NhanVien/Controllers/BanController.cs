using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class BanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DanhSachBan()
        {
            var listBan = db.Bans.ToList();
            return View(listBan);
        }
        public ActionResult XemChiTiet(int iMaBan)
        {
            var ban = db.Bans.Find(iMaBan);
            return View(ban);
        }
        public ActionResult XoaBan(int iMaBan)
        {
            try
            {
                db.Bans.Remove(db.Bans.Find(iMaBan));
                db.SaveChanges();
                return RedirectToAction("DanhSachBan", "Ban");
            }
            catch
            {
                return RedirectToAction("XoaBan", "Error");
            }
        }
        //Thêm bàn
        public ActionResult ThemBan()
        {
            ViewBag.MaTang = db.Tangs;
            return View();
        }
        [HttpPost]
        public ActionResult ThemBan(Ban Model)
        {
            Ban ban = new Ban();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Bans.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Ban");
        }
        //Cập Nhật Bàn
        public ActionResult CapNhatBan(int iMaBan)
        {
            var ban = db.Bans.SingleOrDefault(n => n.MaBan == iMaBan);
            ViewBag.MaTang_id = new SelectList(db.Tangs, "MaTang", "TenTang", ban.MaTang_id); // lẫy mã tầng
            ViewBag.MaTang = db.Tangs;
            return View(ban);
        }
        [HttpPost]
        public ActionResult CapNhatBan(Ban Model)
        {
            Ban ban = new Ban();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Bans.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Ban");
        }
    }
}