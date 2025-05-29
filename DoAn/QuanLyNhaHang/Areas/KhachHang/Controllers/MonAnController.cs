using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class MonAnController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();


        // Xem danh sách món ăn đã đặt
        public ActionResult HoaDon(string phoneNumber)
        {
            var checkPhoneNumber = db.HoaDon.FirstOrDefault(n => n.SDTKhachHang == phoneNumber.Replace("+84", "0") & n.TrangThai == 1);

            if (checkPhoneNumber != null)
            {
                ViewBag.ChiTietHoaDon = db.ChiTietHoaDon.Where(n=>n.MaHoaDon_id == checkPhoneNumber.MaHoaDon).ToList();
                return View(checkPhoneNumber);
            }

            return RedirectToAction("HoaDonTrong", "Error");
        }
    }
}