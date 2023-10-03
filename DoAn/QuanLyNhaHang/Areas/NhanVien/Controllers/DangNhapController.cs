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
                var kh = db.NhanViens.SingleOrDefault(n => n.TaiKhoanNV == ssTaiKhoan & n.MatKhauNV == ssMatKhau);
                if (kh == null)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ !");
                    return View();
                }
                else if (kh.MaQuyen_id == 1) // nhân viên thu ngân
                {
                    Session["TaiKhoanNV"] = kh;
                    return Redirect("/NhanVien/Home/Index");
                }
                else // nhân viên kho
                {
                    Session["TaiKhoanKho"] = kh;
                    return Redirect("/NhanVienKho/Home/Index");
                }
            }

            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}