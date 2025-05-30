using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class TangController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DanhSachTang()
        {
            ViewBag.Tang = db.Tang.Count();
            var list = db.Tang.ToList();
            return View(list);
        }
        public ActionResult XemChiTiet(int iMaTang)
        {
            var tang = db.Tang.SingleOrDefault(n => n.MaTang == iMaTang);
            // Tổng số bàn
            ViewBag.Ban = db.Ban.Where(n => n.MaTang_id == iMaTang).Count();
            return View(tang);
        }

        //Thêm tầng
        public ActionResult ThemTang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTang(Tang model)
        {
            db.Tang.Add(model);
            db.SaveChanges();

            return RedirectToAction("DanhSachTang", "Tang");
        }

        //Cập Nhật Tầng
        public ActionResult CapNhatTang(int iMaTang)
        {
            var tang = db.Tang.Find(iMaTang);
            return View(tang);
        }

        [HttpPost]
        public ActionResult CapNhatTang(Tang model)
        {
            var tang = db.Tang.Find(model.MaTang);
            if (tang != null)
            {
                tang.TenTang = model.TenTang;
                db.SaveChanges();
            }

            return RedirectToAction("DanhSachTang", "Tang");
        }

        // Xóa Tầng
        public ActionResult XoaTang(int iMaTang)
        {
            try
            {
                db.Tang.Remove(db.Tang.Find(iMaTang));
                db.SaveChanges();
                return RedirectToAction("DanhSachTang", "Tang");
            }
            catch
            {
                return RedirectToAction("XoaTang", "Error");
            }
        }
    }
}