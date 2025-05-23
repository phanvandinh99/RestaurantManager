using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class FilterController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        #region Lọc Danh sách món ăn
        public ActionResult LocMonAn(int iMaLMA)
        {
            ViewBag.TatCa = db.MonAns.Count();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            var listFilter = db.MonAns.Where(n => n.MaLMA_id == iMaLMA).ToList();
            return View(listFilter);
        }
        public ActionResult LocMonAnList(int iMaLMA)
        {
            ViewBag.TatCa = db.MonAns.Count();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            var listFilter = db.MonAns.Where(n => n.MaLMA_id == iMaLMA).ToList();
            return View(listFilter);
        }
        #endregion
    }
}