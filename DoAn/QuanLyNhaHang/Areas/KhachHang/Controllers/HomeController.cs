using QuanLyNhaHang.Models;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class HomeController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Hiển thị trang danh sách khách hàng
        public ActionResult Index()
        {
            return View();
        }
    }
}