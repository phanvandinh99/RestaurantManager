using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult DangNhap(FormCollection f)
        {

            // Kiểm tra tên đăng nhập và mật khẩu
            string ssTaiKhoan = f["txtTaiKhoan"].ToString();
            string ssMatKhau = f["txtMatKhau"].ToString();
            if (ssTaiKhoan == "" & ssMatKhau == "")
            {
                ModelState.AddModelError("", "Vui loàng nhập tên đăng nhập và mật khẩu của bạn !");
            }
            else if (ssTaiKhoan == "")
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống tên đăng nhập !");
            }
            else if (ssMatKhau == "")
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống mật khẩu !");
            }
            else
            {
                var kh = db.NhanViens.SingleOrDefault(n => n.TaiKhoanNV == ssTaiKhoan);

                if (kh == null)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ !");
                    return View();
                }

                if (kh != null)
                {
                    if (kh.MatKhauNV != ssMatKhau)// Không đúng mật khẩu
                    {
                        kh.TrangThai = kh.TrangThai + 1;
                        db.SaveChanges();
                        ModelState.AddModelError("", "Bạn nhập sai mật khẩu !");
                    }
                }

                if (kh.TrangThai == 4)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa !");
                }

                else if (kh.MaQuyen_id == 1) // nhân viên thu ngân
                {

                    Session["TaiKhoanNV"] = kh;
                    kh.TrangThai = 0;
                    return Redirect("/NhanVien/Home/Index");
                }
                else if (kh.MaQuyen_id == 3) // Nhân viên admin
                {
                    Session["Admin"] = kh;
                    kh.TrangThai = 0;
                    return Redirect("/Admin/Home/Index");
                }
                else // nhân viên kho
                {
                    Session["TaiKhoanKho"] = kh;
                    kh.TrangThai = 0;
                    return Redirect("/NhanVienKho/Home/Index");
                }
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