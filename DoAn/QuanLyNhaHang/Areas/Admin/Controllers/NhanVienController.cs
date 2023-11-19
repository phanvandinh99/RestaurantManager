using QuanLyNhaHang.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Hiển thị danh sách nhân viên 
        public ActionResult DSNhanVien()
        {
            var list = db.NhanViens.Where(n => n.MaQuyen_id == 1).ToList();
            return View(list);
        }

        // Hiển thị danh sách nhân viên kho
        public ActionResult DSNhanVienKho()
        {
            var list = db.NhanViens.Where(n => n.MaQuyen_id == 2).ToList();
            return View(list);
        }

        // Hiển thị danh sách phục vụ
        public ActionResult DSNhanVienPhucVu()
        {
            var list = db.NhanViens.Where(n => n.MaQuyen_id == 4).ToList();
            return View(list);
        }

        // Danh sách nhân viên có tài khoản bị khóa 
        public ActionResult DSNhanVienKhoa()
        {
            var list = db.NhanViens.Where(n => n.TrangThai == 4).ToList();
            return View(list);
        }

        public ActionResult LockAccount(string sTaiKhoanNV)
        {
            var nhanvien = db.NhanViens.FirstOrDefault(n => n.TaiKhoanNV == sTaiKhoanNV);
            if(nhanvien.TrangThai == 4) // Đang bị khóa
            {
                nhanvien.TrangThai = 0;
            }
            else // Chưa khóa 
            {
                nhanvien.TrangThai = 4;
            }
            db.SaveChanges();

            return RedirectToAction("DSNhanVienKhoa", "Nhanvien");
        }

        // Mở/Khóa tài khoản


        // Thêm mới nhân vien
        public ActionResult ThemNhanVien()
        {
            ViewBag.Quyen = db.Quyens.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ThemNhanVien(QuanLyNhaHang.Models.NhanVien Model)
        {
            db.NhanViens.Add(Model);
            db.SaveChanges();
            return RedirectToAction("DSNhanVien", "NhanVien");
        }

        // Xóa nhân viên
        public ActionResult Xoa(string sTaiKhoanid)
        {
            var nhanVien = db.NhanViens.Find(sTaiKhoanid);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("DSNhanVien", "NhanVien");
        }

        // Xem chi tiết nhân viên
        public ActionResult XemChiTiet(string sTaiKhoanid)
        {
            var nhanVien = db.NhanViens.Find(sTaiKhoanid);
            return View(nhanVien);
        }

        // Cập nhật nhân viên
        public ActionResult CapNhat(string sTaiKhoanid)
        {
            QuanLyNhaHang.Models.NhanVien nhanVien = db.NhanViens.Find(sTaiKhoanid);
            ViewBag.MaQuyen_id = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", nhanVien.MaQuyen_id);
            return View(nhanVien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhat([Bind(Include = "TaiKhoanNV,MatKhauNV,TenNhanVien,NgaySinh,SoDienThoai,MaQuyen_id")] QuanLyNhaHang.Models.NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSNhanVien", "NhanVien");
            }
            ViewBag.MaQuyen_id = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", nhanVien.MaQuyen_id);
            return View();
        }
    }
}