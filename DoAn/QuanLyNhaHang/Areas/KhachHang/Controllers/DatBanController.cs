using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class DatBanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();


        // Danh sách đặt bàn của bạn
        public ActionResult Index(string sTaiKhoanKH)
        {
            var datBan = db.DatBan.Where(n=>n.TaiKhoanKH_id == sTaiKhoanKH).ToList();
            return View(datBan);
        }

        public ActionResult DatBan()
        {
            return View();
        }
    }
}