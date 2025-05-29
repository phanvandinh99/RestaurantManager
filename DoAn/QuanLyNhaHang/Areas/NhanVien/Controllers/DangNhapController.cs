using QuanLyNhaHang.Models;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class DangNhapController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string sTaiKhoan, string sMatKhau)
        {
            if (string.IsNullOrEmpty(sTaiKhoan))
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống tên đăng nhập!");
                return View();
            }
            else if (string.IsNullOrEmpty(sMatKhau))
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống mật khẩu!");
                return View();
            }
            else
            {
                var nguoiDung = db.NhanVien.Find(sTaiKhoan);

                if (nguoiDung == null)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ !");
                    return View();
                }
                else if (nguoiDung != null)
                {
                    if (nguoiDung.MatKhauNV != sMatKhau && nguoiDung.TrangThai != 4) // Không đúng mật khẩu
                    {
                        nguoiDung.TrangThai = nguoiDung.TrangThai + 1;
                        int? LuotDangNhap = 3;
                        LuotDangNhap = LuotDangNhap - nguoiDung.TrangThai;
                        db.SaveChanges();

                        ModelState.AddModelError("", "Bạn nhập sai mật khẩu !,\nCòn " + LuotDangNhap + " Lượt");
                        return View();
                    }
                }

                if (nguoiDung.TrangThai == 4)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa !");
                    return View();
                }

                switch (nguoiDung.MaQuyen_id)
                {
                    // nhân viên thu ngân
                    case 1:
                        Session["TaiKhoanNV"] = nguoiDung;
                        nguoiDung.TrangThai = 0;
                        db.SaveChanges();
                        return Redirect("/NhanVien/Home/Index");

                    // nhân viên kho
                    case 2:
                        Session["TaiKhoanKho"] = nguoiDung;
                        nguoiDung.TrangThai = 0;
                        db.SaveChanges();
                        return Redirect("/NhanVienKho/Home/Index");

                    // Nhân viên admin
                    case 3:
                        Session["Admin"] = nguoiDung;
                        nguoiDung.TrangThai = 0;
                        db.SaveChanges();
                        return Redirect("/Admin/Home/Index");
                };
            }

            return View();
        }

        public ActionResult DangXuatNhanVien()
        {
            Session["TaiKhoanNV"] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }

        public ActionResult DangXuatNhanVienKho()
        {
            Session["TaiKhoanKho"] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }

        public ActionResult DangXuatAdmin()
        {
            Session["Admin"] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }
    }
}