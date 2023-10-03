﻿using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class MonAnController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // hiển thị danh sách các món ăn
        public ActionResult DanhSachMonAn()
        {
            ViewBag.TatCa = db.MonAns.Count();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            var listMonAn = db.MonAns.OrderBy(n => n.MaMonAn).ToList();
            return View(listMonAn);
        }
        public ActionResult DanhSachMonAnList()
        {
            ViewBag.TatCa = db.MonAns.Count();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            var listMonAn = db.MonAns.OrderBy(n => n.MaMonAn).ToList();
            return View(listMonAn);
        }
        public ActionResult DanhSachMonAnBanChay()
        {
            ViewBag.TatCa = db.MonAns.Count();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            var listMonAn = db.MonAns.Where(n => n.MaMonAn != 1 & n.MaMonAn != 10 && n.MaMonAn != 9).OrderBy(n => n.SoLuongDaBan).ToList().Take(10);
            return View(listMonAn);
        }

        public ActionResult XoaMonAn(int iMaMonAn)
        {
            try
            {
                var chiTietMonAn = db.ChiTietSanPhams.Where(n => n.MaMonAn_id == iMaMonAn).ToList();
                // xóa chi tiết món ăn
                foreach (var item in chiTietMonAn)
                {
                    db.ChiTietSanPhams.Remove(item);
                }
                // xóa Món Ăn
                var monAn = db.MonAns.Find(iMaMonAn);
                db.MonAns.Remove(monAn);
                db.SaveChanges();
                return RedirectToAction("XoaMonAnThanhCong", "Error");
            }
            catch
            {
                return RedirectToAction("XoaMonAn", "Error");
            }
        }

        public ActionResult XemChiTiet(int iMaMonAn)
        {
            var monAn = db.MonAns.Find(iMaMonAn);
            // lấy m ón ăn cùng loại
            var monAnCungLoai = db.MonAns.Where(n => n.MaLMA_id == monAn.MaLMA_id).ToList().Take(5);
            ViewBag.MonAnCungLoai = monAnCungLoai;
            // lấy chi tiết món ăn
            var chiTietMonAn = db.ChiTietSanPhams.Where(n => n.MaMonAn_id == iMaMonAn).ToList().OrderByDescending(n => n.Tru);
            ViewBag.ChiTietMonAn = chiTietMonAn;
            return View(monAn);
        }
        public ActionResult ThemMonAn()
        {
            ViewBag.NhomMonAn = db.NhomMonAns.ToList();
            ViewBag.LoaiMonAn = db.LoaiMonAns.ToList();
            ViewBag.NguyenLieu = db.NguyenLieus.Where(n => n.MaLNL_id != 4 & n.MaNguyenLieu != 1).ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMonAn(HttpPostedFileBase HinhAnh, MonAn Model, IEnumerable<ChiTietSanPham> listCTSP)
        {
            try
            {
                ViewBag.NhomMonAn = db.NhomMonAns.ToList();
                ViewBag.LoaiMonAn = db.NhomMonAns.ToList();
                ViewBag.NguyenLieu = db.NguyenLieus.ToList();
                #region Lưu hình ảnh vào thư mục
                if (HinhAnh.ContentLength > 0)
                {
                    var tenAnh = Path.GetFileName(HinhAnh.FileName);
                    var duongDan = Path.Combine(Server.MapPath("~/Assets/img/AnhMonAn"), tenAnh);
                    if (System.IO.File.Exists(duongDan))
                    {
                        ViewBag.upload = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        HinhAnh.SaveAs(duongDan);
                    }
                }
                #endregion

                #region Thêm Món Ăn Vào DATA
                MonAn monAn = new MonAn();
                monAn.TenMonAn = Model.TenMonAn;
                monAn.HinhAnh = HinhAnh.FileName;
                monAn.DonGia = Model.DonGia;
                monAn.NgayCapNhat = DateTime.Now;
                monAn.ThongTin = Model.ThongTin;
                monAn.MoTa = Model.MoTa;
                monAn.SoLuongDaBan = 0;
                monAn.MaNMA_id = Model.MaNMA_id;
                monAn.MaLMA_id = Model.MaLMA_id;
                db.MonAns.Add(monAn);
                db.SaveChanges();
                #endregion
                //Lấy id mã món ăn
                var maMonAn = db.MonAns.OrderByDescending(n => n.MaMonAn).FirstOrDefault();
                #region Thêm món ăn vào chi tiết sản phẩm
                if (listCTSP != null)
                {
                    foreach (var item in listCTSP) // chi tiết phiếu nhật
                    {
                        ChiTietSanPham ctsp = new ChiTietSanPham();
                        //kiểm tra chi tiết sản phẩm đã tồn tại chưa
                        var chiTietSanPham = db.ChiTietSanPhams.SingleOrDefault(n => n.MaMonAn_id == maMonAn.MaMonAn && n.MaNguyenLieu_id == item.MaNguyenLieu_id);
                        if (chiTietSanPham != null)
                        {
                            chiTietSanPham.SoLuongDung += item.SoLuongDung;
                            chiTietSanPham.Tru = item.Tru;
                            db.SaveChanges();
                        }
                        else
                        {
                            ctsp.MaMonAn_id = maMonAn.MaMonAn;
                            ctsp.MaNguyenLieu_id = item.MaNguyenLieu_id;
                            ctsp.SoLuongDung = item.SoLuongDung;
                            ctsp.Tru = item.Tru;
                            db.ChiTietSanPhams.Add(ctsp);
                            db.SaveChanges();
                        }
                    }
                }
                #endregion
                return RedirectToAction("DanhSachMonAn", "MonAn");
            }
            catch
            {
                return RedirectToAction("MonAn", "Error");
            }
        }
    }
}