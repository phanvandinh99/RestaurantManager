using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class BanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DanhSachBan()
        {
            var listBan = db.Ban.ToList();
            return View(listBan);
        }

        public ActionResult XemChiTiet(int iMaBan)
        {
            var ban = db.Ban.Find(iMaBan);
            return View(ban);
        }

        public ActionResult XoaBan(int iMaBan)
        {
            try
            {
                db.Ban.Remove(db.Ban.Find(iMaBan));
                db.SaveChanges();
                return RedirectToAction("DanhSachBan", "Ban");
            }
            catch
            {
                return RedirectToAction("XoaBan", "Error");
            }
        }

        //Thêm bàn
        public ActionResult ThemBan()
        {
            ViewBag.MaTang = db.Tang;
            return View();
        }

        [HttpPost]
        public ActionResult ThemBan(Ban Model)
        {
            Ban ban = new Ban();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Ban.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Ban");
        }

        //Cập Nhật Bàn
        public ActionResult CapNhatBan(int iMaBan)
        {
            var ban = db.Ban.SingleOrDefault(n => n.MaBan == iMaBan);
            ViewBag.MaTang_id = new SelectList(db.Tang, "MaTang", "TenTang", ban.MaTang_id); // lẫy mã tầng
            ViewBag.MaTang = db.Tang;
            return View(ban);
        }
        [HttpPost]
        public ActionResult CapNhatBan(Ban Model)
        {
            Ban ban = new Ban();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Ban.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Ban");
        }
    }
}