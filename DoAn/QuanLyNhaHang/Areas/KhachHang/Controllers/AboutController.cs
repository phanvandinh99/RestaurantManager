using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class AboutController : Controller
    {
        // GET: KhachHang/About
        public ActionResult SuKien()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }
    }
}