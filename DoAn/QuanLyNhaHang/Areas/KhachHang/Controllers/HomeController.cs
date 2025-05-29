using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class HomeController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Hiển thị trang danh sách khách hàng
        public ActionResult Index()
        {
            var listSanPham = db.MonAn.ToList();
            return View(listSanPham);
        }
    }
}