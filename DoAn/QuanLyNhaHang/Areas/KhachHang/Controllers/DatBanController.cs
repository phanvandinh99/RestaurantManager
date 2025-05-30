using QuanLyNhaHang.Models;
using System;
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
            var datBan = db.DatBan.Where(n => n.TaiKhoanKH_id == sTaiKhoanKH).ToList();
            return View(datBan);
        }

        #region Đặt bàn và gọi món
        public ActionResult DatBan()
        {
            // Kiểm tra đăng nhập
            //if (Session["TaiKhoanKH"] == null)
            //{
            //    return RedirectToAction("DangNhap", "DangNhap");
            //}

            ViewBag.MonAn = db.MonAn.ToList();

            return View();
        }

        // POST: /KhachHang/DatBan/DatBan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatBan(DatBan datBanModel, int[] MaMonAn_id, int[] SoLuong)
        {
            if (Session["TaiKhoanKH"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            // Validate ThoiGianBatDau
            if (datBanModel.ThoiGianBatDau < DateTime.Now)
            {
                ModelState.AddModelError("ThoiGianBatDau", "Thời gian bắt đầu trước thời gian hiện tại.");
                ViewBag.MonAn = db.MonAn.ToList();
                return View(datBanModel);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var khachHang = Session["TaiKhoanKH"] as QuanLyNhaHang.Models.KhachHang;

                    var datBan = new DatBan
                    {
                        ThoiGianDat = DateTime.Now,
                        ThoiGianBatDau = datBanModel.ThoiGianBatDau,
                        ThoiGianKetThuc = datBanModel.ThoiGianBatDau.AddHours(2),
                        SoNguoi = datBanModel.SoNguoi,
                        MaBan_id = datBanModel.MaBan_id,
                        TaiKhoanKH_id = khachHang.TaiKhoanKH,
                        TrangThai = 0, // Pending
                        TongTienTamTinh = 0,
                        SoTienCoc = 0
                    };
                    db.DatBan.Add(datBan);
                    db.SaveChanges();

                    // Add pre-ordered dishes
                    if (MaMonAn_id != null && SoLuong != null && MaMonAn_id.Length == SoLuong.Length)
                    {
                        double total = 0;
                        for (int i = 0; i < MaMonAn_id.Length; i++)
                        {
                            if (SoLuong[i] > 0)
                            {
                                var monAn = db.MonAn.Find(MaMonAn_id[i]);
                                if (monAn != null)
                                {
                                    var goiMonTruoc = new GoiMonTruoc
                                    {
                                        SoLuong = SoLuong[i],
                                        DonGia = monAn.DonGia,
                                        MaMonAn_id = MaMonAn_id[i],
                                        MaDatBan_id = datBan.MaDatBan
                                    };
                                    db.GoiMonTruoc.Add(goiMonTruoc);
                                    total += SoLuong[i] * monAn.DonGia.GetValueOrDefault();
                                }
                            }
                        }
                        datBan.TongTienTamTinh = total;
                        datBan.SoTienCoc = total * 0.2; // 20% deposit
                    }

                    // Save DatBan first to get MaDatBan
                    db.SaveChanges();

                    //// Update MaDatBan_id for GoiMonTruoc entries
                    //foreach (var goiMon in datBan.GoiMonTruoc)
                    //{
                    //    goiMon.MaDatBan_id = datBan.MaDatBan;
                    //}
                    db.SaveChanges();

                    return RedirectToAction("Index", "DatBan", new { area = "KhachHang", sTaiKhoanKH = khachHang.TaiKhoanKH });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Lỗi khi lưu đặt bàn!");
                }
            }

            // Reload data if validation fails
            ViewBag.MonAn = db.MonAn.ToList();
            ViewBag.MaBan_id = new SelectList(db.Ban, "MaBan", "TenBan");
            return View(datBanModel);
        }
        #endregion

        #region Xóa đặt bàn
        // GET: /KhachHang/DatBan/Cancel/5
        public ActionResult HuyDatBan(int iMaDatBan)
        {
            if (Session["TaiKhoanKH"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            var khachHang = Session["TaiKhoanKH"] as QuanLyNhaHang.Models.KhachHang;

            var datBan = db.DatBan.Find(iMaDatBan);
            if (datBan == null || datBan.TaiKhoanKH_id != khachHang.TaiKhoanKH)
            {
                return HttpNotFound();
            }

            try
            {
                datBan.TrangThai = 2; // Cancelled
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi hủy đặt bàn: {ex.Message}";
            }

            return RedirectToAction("Index", "DatBan", new { area = "KhachHang", sTaiKhoanKH = khachHang.TaiKhoanKH });
        }
        #endregion
    }
}