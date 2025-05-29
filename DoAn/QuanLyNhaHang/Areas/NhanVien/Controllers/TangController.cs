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
            ViewBag.Tang = db.Tangs.Count();
            var list = db.Tangs.ToList();
            return View(list);
        }
        public ActionResult XemChiTiet(int iMaTang)
        {
            var tang = db.Tangs.SingleOrDefault(n => n.MaTang == iMaTang);
            // Tổng số bàn
            ViewBag.Ban = db.Bans.Where(n => n.MaTang_id == iMaTang).Count();
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
            db.Tangs.Add(model);
            db.SaveChanges();

            return RedirectToAction("DanhSachTang", "Tang");
        }

        //Cập Nhật Tầng
        public ActionResult CapNhatTang(int iMaTang)
        {
            var tang = db.Tangs.Find(iMaTang);
            return View(tang);
        }

        [HttpPost]
        public ActionResult CapNhatTang(Tang model)
        {
            Tang tang = new Tang();
            tang.TenTang= model.TenTang;

            db.Tangs.Add(tang);
            db.SaveChanges();
            return RedirectToAction("DanhSachTang", "Tang");
        }

        // Xóa Tầng
        public ActionResult XoaTang(int iMaTang)
        {
            try
            {
                db.Tangs.Remove(db.Tangs.Find(iMaTang));
                db.SaveChanges();
                return RedirectToAction("DanhSachTang", "Ban");
            }
            catch
            {
                return RedirectToAction("XoaTang", "Error");
            }
        }
    }
}