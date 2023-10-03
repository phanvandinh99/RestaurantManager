using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class TangController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DanhSachTang()
        {
            ViewBag.Tang = db.Tangs.Count();
            var list = db.Tangs.ToList();
            return View(list);
        }
        public ActionResult XemChiTiet(int iMaTang)
        {
            var tang = db.Tangs.SingleOrDefault(n => n.MaTang == iMaTang);
            // Tổng số bàn 
            ViewBag.Tang = db.Bans.Where(n => n.MaTang_id == iMaTang).Count();
            return View(tang);
        }
        public ActionResult CapNhat(int iMaTang)
        {
            var tang = db.Tangs.SingleOrDefault(n => n.MaTang == iMaTang);
            // Tổng số bàn 
            ViewBag.Tang = db.Bans.Where(n => n.MaTang_id == iMaTang).Count();
            return View(tang);
        }
    }
}