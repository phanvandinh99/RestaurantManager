using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class SanPhamController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // GET: KhachHang/SanPham
        public ActionResult Index()
        {
            return View();
        }

        // Xem chi tiết món ăn
        public ActionResult XemChiTiet(int iMaMonAn)
        {
            var monAn = db.MonAns.FirstOrDefault(n => n.MaMonAn == iMaMonAn);

            // Hiển món ăn liên quan
            ViewBag.MonAnLienQuan = db.MonAns.Where(n => n.MaLMA_id == monAn.MaLMA_id).ToList().Take(4);

            // lấy chi tiết món ăn
            ViewBag.ChiTietMonAn  = db.ChiTietSanPhams.Where(n => n.MaMonAn_id == iMaMonAn).ToList().OrderByDescending(n => n.Tru);

            return View(monAn);
        }
    }
}