using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVienKho.Controllers
{
    public class FilterController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        #region Lọc Danh sách món ăn
        public ActionResult LocNguyenLieu(int iMaLNL)
        {
            ViewBag.ListNguyenLieu = db.LoaiNguyenLieus.ToList();
            ViewBag.TatCa = db.NguyenLieus.Count();
            var listNguyenLieu = db.NguyenLieus.Where(n=>n.MaLNL_id== iMaLNL);
            return View(listNguyenLieu);
        }
        public ActionResult LocNhapNguyenLieu(int iMaLNL)
        {
            ViewBag.ListNguyenLieu = db.LoaiNguyenLieus.ToList();
            ViewBag.TatCa = db.LoaiNguyenLieus.Count();
            ViewBag.NguyenLieu = db.NguyenLieus.Where(n => n.MaLNL_id == iMaLNL);
            ViewBag.NhanVien = db.NhanViens.Where(n => n.MaQuyen_id == 2).ToList(); //1 nhân viên, 2 kho
            ViewBag.NhaCungCap = db.NhaCCs.ToList();
            return View();
        }
        #endregion
    }
}