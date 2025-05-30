using QuanLyNhaHang.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class DatBanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Danh sách đặt bàn khách hàng
        public ActionResult Index(int? iTrangThai)
        {
            var listDatBan = db.DatBan
                .Where(n => iTrangThai == 2 ? n.TrangThai == 2 : n.TrangThai != 2)
                .OrderBy(n => n.ThoiGianBatDau)
                .ToList();

            return View(listDatBan);
        }

        #region Xác nhận đặt cọc
        public ActionResult XacNhanDatCoc(int iMaDatBan)
        {
            var datBan = db.DatBan.Find(iMaDatBan);
            if (datBan == null)
            {
                return HttpNotFound();
            }

            try
            {
                datBan.TrangThai = 1; // Đã đặ bàn
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi hủy đặt bàn: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Hủy đặt bàn
        public ActionResult HuyDatBan(int iMaDatBan)
        {
            var datBan = db.DatBan.Find(iMaDatBan);
            if (datBan == null)
            {
                return HttpNotFound();
            }

            try
            {
                datBan.TrangThai = 2; // Cancelled
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi hủy đặt bàn: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}