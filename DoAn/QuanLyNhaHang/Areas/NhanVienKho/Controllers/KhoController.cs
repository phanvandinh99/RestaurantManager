﻿using QuanLyNhaHang.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;

namespace QuanLyNhaHang.Areas.NhanVienKho.Controllers
{
    public class KhoController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        #region Nhập Kho
        [HttpGet]
        public ActionResult NhapKho()
        {
            ViewBag.ListNguyenLieu = db.LoaiNguyenLieus.ToList();
            ViewBag.TatCa = db.LoaiNguyenLieus.Count();
            ViewBag.NguyenLieu = db.NguyenLieus.ToList().OrderBy(n=>n.TenNguyenLieu);
            ViewBag.NhanVien = db.NhanViens.Where(n => n.MaQuyen_id == 2).ToList(); //1 nhân viên, 2 kho
            ViewBag.NhaCungCap = db.NhaCCs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult NhapKho(PhieuNhap Model, IEnumerable<ChiTietPhieuNhap> lstModel)
        {
            //try
            //{
                double? TongTien = 0;
                if(Model.NgayNhap==null)
                {
                    Model.NgayNhap = DateTime.Now;
                }
                db.PhieuNhaps.Add(Model);
                db.SaveChanges();
                // lấy mã phiếu nhập savechang để gán cho lít chi tiết phiếu nhập
                foreach (var item in lstModel) // chi tiết phiếu nhập
                {
                    // gan ma phieu nhap cho ca chi tiet phieu nhap
                    item.MaPhieuNhap_id = Model.MaPhieuNhap;
                    item.ThanhTien = (item.SoLuongNhap * item.GiaNhap);
                    TongTien = TongTien + item.ThanhTien;

                    #region Cộng số lượng hiện có của nguyên liệu
                    var slNguyenLieu = db.NguyenLieus.SingleOrDefault(n => n.MaNguyenLieu == item.MaNguyenLieu_id);
                    slNguyenLieu.SoLuongHienCon += item.SoLuongNhap;
                    slNguyenLieu.GiaNhapCuoi = item.GiaNhap;
                    #endregion
                }
                db.ChiTietPhieuNhaps.AddRange(lstModel);
                PhieuNhap pn = db.PhieuNhaps.SingleOrDefault(n => n.MaPhieuNhap == Model.MaPhieuNhap);
                pn.TongTien = (double)TongTien;
                db.SaveChanges();

                return RedirectToAction("DanhSachPhieuNhap", "PhieuNhap");
            //}
            //catch
            //{
            //    return RedirectToAction("TrungSanPhamKhiNhap", "Error");
            //}

        }
        #endregion


    }
}