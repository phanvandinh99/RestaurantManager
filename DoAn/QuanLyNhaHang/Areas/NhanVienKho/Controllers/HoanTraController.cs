using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVienKho.Controllers
{
    public class HoanTraController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        // Danh sách phiếu xuất
        public ActionResult DanhSachPhieuHoanTra()
        {
            var listHoanTra = db.HoanTras.ToList().OrderByDescending(n => n.MaHoanTra);
            return View(listHoanTra);
        }
        // Xem chi tiết phiếu xuất
        public ActionResult ChiTiet(int iMaHoanTra)
        {
            var hoanTra = db.HoanTras.SingleOrDefault(n => n.MaHoanTra == iMaHoanTra);
            ViewBag.NguyenlieuTra = db.NguyenLieuTras.Where(n => n.MaHoanTra_id == iMaHoanTra).ToList();

            return View(hoanTra);
        }
        // Xóa phiếu xuất
        public ActionResult XoaPhieuHoanTra(int iMaHoanTra)
        {
            var listNguyenlieuHoanTra = db.NguyenLieuTras.Where(n => n.MaHoanTra_id == iMaHoanTra);
            if (listNguyenlieuHoanTra != null)
            {
                foreach (var item in listNguyenlieuHoanTra)
                {
                    db.NguyenLieuTras.Remove(item);
                }
            }
            var phieuTra = db.HoanTras.SingleOrDefault(n => n.MaHoanTra == iMaHoanTra);
            db.HoanTras.Remove(phieuTra);
            db.SaveChanges();
            return RedirectToAction("DanhSachPhieuHoanTra", "HoanTra");
        }

        #region Thêm mới hoàn trả kho
        [HttpGet]
        public ActionResult PhieuHoanTraKho()
        {
            ViewBag.NguyenLieu = db.NguyenLieus.ToList().OrderBy(n => n.TenNguyenLieu);
            return View();
        }
        [HttpPost]
        public ActionResult PhieuHoanTraKho(HoanTra Model, IEnumerable<NguyenLieuTra> lstModel)
        {
            #region Lưu hoàn trả
            HoanTra ht = new HoanTra();
            if (Model.NgayHoanTra == null)
            {
                ht.NgayHoanTra = DateTime.Now;
            }
            else
            {
                ht.NgayHoanTra = Model.NgayHoanTra;
            }
            db.HoanTras.Add(ht);
            db.SaveChanges();
            #endregion
            // lấy mã xuất kho
            var maXuatKho = db.HoanTras.OrderByDescending(n => n.MaHoanTra).FirstOrDefault();

            foreach (var item in lstModel) // chi tiết phiếu xuất
            {

                // tìm mã nguyên liệu
                var nguyenLieu = db.NguyenLieus.SingleOrDefault(n => n.MaNguyenLieu == item.MaNguyenLieu_id);
                // kiểm tra nếu nhập số lẽ với thức uống
                if (nguyenLieu.MaLNL_id == 4) // mã nguyên thức uống == 4
                {
                    int SL;
                    if (int.TryParse(item.SoLuongTra.ToString(), out SL))
                    {
                        NguyenLieuTra nltThucUong = new NguyenLieuTra();
                        nltThucUong.MaHoanTra_id = maXuatKho.MaHoanTra;
                        nltThucUong.MaNguyenLieu_id = item.MaNguyenLieu_id;
                        nltThucUong.SoLuongTra = item.SoLuongTra;
                        db.NguyenLieuTras.Add(nltThucUong);
                        db.SaveChanges();
                        #region Cộng số lượng số lượng trong kho
                        var slNguyenLieus = db.NguyenLieus.SingleOrDefault(n => n.MaNguyenLieu == item.MaNguyenLieu_id);
                        slNguyenLieus.SoLuongHienCon = slNguyenLieus.SoLuongHienCon + item.SoLuongTra;
                        db.SaveChanges();
                        #endregion
                    }
                    else // số lượng thức uống lẽ ví dụ: 1,5 chai, 2,5 chai
                    {
                        // Không in cái đó ra
                    }
                }
                else
                {
                    NguyenLieuTra nlt = new NguyenLieuTra();
                    nlt.MaHoanTra_id = maXuatKho.MaHoanTra;
                    nlt.MaNguyenLieu_id = item.MaNguyenLieu_id;
                    nlt.SoLuongTra = item.SoLuongTra;
                    db.NguyenLieuTras.Add(nlt);
                    db.SaveChanges();
                    #region Cộng số lượng số lượng trong kho
                    var slNguyenLieu = db.NguyenLieus.SingleOrDefault(n => n.MaNguyenLieu == item.MaNguyenLieu_id);
                    slNguyenLieu.SoLuongHienCon = slNguyenLieu.SoLuongHienCon + item.SoLuongTra;
                    db.SaveChanges();
                    #endregion
                }
                #endregion
            }
            //db.SaveChanges();
            return RedirectToAction("DanhSachPhieuHoanTra", "HoanTra");
        }
    }
}
