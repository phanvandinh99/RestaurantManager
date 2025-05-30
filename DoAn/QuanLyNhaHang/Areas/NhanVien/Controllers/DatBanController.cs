using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class DatBanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Danh sách đặt bàn khách hàng
        public ActionResult Index(int? iTrangThai)
        {
            var listDatBan = db.DatBan
                .Where(n => iTrangThai == 2 ? n.TrangThai == 2 : n.TrangThai != 2)
                .OrderBy(n => n.ThoiGianBatDau)
                .ToList();

            return View(listDatBan);
        }

    }
}