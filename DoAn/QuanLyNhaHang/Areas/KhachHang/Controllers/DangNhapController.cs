using QuanLyNhaHang.Common;
using QuanLyNhaHang.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class DangNhapController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        private readonly SmsService _smsService;

        public DangNhapController()
        {
            _smsService = new SmsService();
        }

        // Trang Đăng Nhập
        public ActionResult DangNhap()
        {
            return View();
        }

        // Thực Hiện Chức Năng Đăng Nhập
        [HttpPost]
        public ActionResult SendSmsAuthentication(string phoneNumber)
        {
            // Convert phoneNumber thành 
            // Kiểm tra số điện thoại của bạn đã tạo bàn chưa?
            var checkPhoneNumber = db.HoaDons.FirstOrDefault(n => n.SDTKhachHang == phoneNumber.Replace("+84", "0") & n.TrangThai == 1);

            if (checkPhoneNumber == null)
            {
                // Trường hợp chưa tạo bàn cần liên hệ nhân viên để đặ bàn => trở về đặt bàn
                return RedirectToAction("DatBan", "DatBan");
            }

            string authenticationCode = GenerateRandomCode(6);

            checkPhoneNumber.ThoiHan = DateTime.Now;
            checkPhoneNumber.Code = authenticationCode;
            db.SaveChanges();

            // Giả sử bạn đã tạo mã xác thực
            var messageBody = $"Welcome to Cafeu.\nMã xác thực của bạn là: {authenticationCode}\nMã có hiệu lực trong vòng 1 phút.";

            // Gửi tin nhắn SMS
            _smsService.SendSms(phoneNumber, messageBody);

            // Tìm ra thông tin hoá đơn và cập nhật mã code vào password

            // Tiến hành đến trang xác thực và kiểm tra

            // Thêm mã xử lý bổ sung
            ViewBag.phoneNumber = phoneNumber;

            return View();
        }

        // Xác thực mã code có đúng hay không để tiến trìn đăng nhập
        [HttpPost]
        public ActionResult CheckCode(string phoneNumber, string code)
        {
            var checkPhoneNumber = db.HoaDons.FirstOrDefault(n => n.SDTKhachHang == phoneNumber.Replace("+84", "0") & n.TrangThai == 1);

            DateTime? thoiHan = checkPhoneNumber.ThoiHan;
            TimeSpan timeDifference = thoiHan.Value.Subtract(DateTime.Now);

            if (checkPhoneNumber.Code == code &&
                timeDifference.TotalMinutes <= 1
               )
            {
                var userCookie = new HttpCookie("UserCookie");
                userCookie["user"] = checkPhoneNumber.TenKhachHang;
                userCookie["phone"] = checkPhoneNumber.SDTKhachHang;
                userCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(userCookie);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private string GenerateRandomCode(int length)
        {
            const string validChars = "0123456789";
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];
                char[] chars = new char[length];
                int max = validChars.Length;
                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    chars[i] = validChars[(int)(num % (uint)max)];
                }
                return new string(chars);
            }
        }

    }
}