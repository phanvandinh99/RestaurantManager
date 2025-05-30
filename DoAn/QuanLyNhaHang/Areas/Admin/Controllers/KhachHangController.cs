using QuanLyNhaHang.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Hiển thị danh sách khách hàng
        public ActionResult Index()
        {
            var list = db.KhachHang.ToList();
            return View(list);
        }

        // Mở/Khóa tài khoản
        public ActionResult LockAccount(string sTaiKhoankh)
        {
            var khachHang = db.KhachHang.FirstOrDefault(n => n.TaiKhoanKH == sTaiKhoankh);
            if (khachHang.TrangThai != 0) // Đang bị khóa
            {
                khachHang.TrangThai = 0;
            }
            else // Chưa khóa 
            {
                khachHang.TrangThai = 1;
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Xóa khách hàng
        public ActionResult Xoa(string sTaiKhoanKH)
        {
            var khachHang = db.KhachHang.Find(sTaiKhoanKH);
            db.KhachHang.Remove(khachHang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Xem chi tiết khách hàng
        public ActionResult XemChiTiet(string sTaiKhoanKH)
        {
            var khachHang = db.KhachHang.Find(sTaiKhoanKH);
            return View(khachHang);
        }

        // Cập nhật Khách hàng
        public ActionResult CapNhat(string sTaiKhoanKH)
        {
            var khachHang = db.KhachHang.Find(sTaiKhoanKH);

            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhat(QuanLyNhaHang.Models.KhachHang model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}