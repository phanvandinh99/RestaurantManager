﻿using QuanLyNhaHang.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVienKho.Controllers
{
    public class NguyenLieuController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // Hiển thị danh sách nguyên liệu
        public ActionResult ListNguyenLieu()
        {
            ViewBag.ListNguyenLieu = db.LoaiNguyenLieus.ToList();
            ViewBag.TatCa = db.NguyenLieus.Count();
            var listNguyenLieu = db.NguyenLieus.ToList().OrderBy(n => n.TenNguyenLieu);
            return View(listNguyenLieu);
        }
        //Xem chi tiết
        public ActionResult XemChiTiet(int? iMaNguyenLieu)
        {
            NguyenLieu nguyenLieu = db.NguyenLieus.Find(iMaNguyenLieu);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }
        // Cập nhật
        public ActionResult CapNhat(int? iMaNguyenLieu)
        {
            NguyenLieu nguyenLieu = db.NguyenLieus.Find(iMaNguyenLieu);
            ViewBag.MaLNL_id = new SelectList(db.LoaiNguyenLieus, "MaLNL", "TenLNL", nguyenLieu.MaLNL_id);
            return View(nguyenLieu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhat([Bind(Include = "MaNguyenLieu,TenNguyenLieu,SoLuongHienCon,GhiChu,MaLNL_id")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguyenLieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListNguyenLieu", "NguyenLieu");
            }
            ViewBag.MaLNL_id = new SelectList(db.LoaiNguyenLieus, "MaLNL", "TenLNL", nguyenLieu.MaLNL_id);
            return View(nguyenLieu);
        }

        // Xóa
        public ActionResult Xoa(int iMaNguyenLieu)
        {
            try
            {
                NguyenLieu nguyenLieu = db.NguyenLieus.Find(iMaNguyenLieu);
                db.NguyenLieus.Remove(nguyenLieu);
                db.SaveChanges();
                return RedirectToAction("HaiSan", "NguyenLieu");
            }
            catch
            {
                return RedirectToAction("KhoaNgoai", "Error");
            }

        }

        // Thêm mới
        public ActionResult ThemMoi()
        {
            ViewBag.MaLNL_id = new SelectList(db.LoaiNguyenLieus, "MaLNL", "TenLNL");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi([Bind(Include = "MaNguyenLieu,TenNguyenLieu,SoLuongHienCon,GhiChu,MaLNL_id")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                NguyenLieu nl = new NguyenLieu();
                nl.TenNguyenLieu = nguyenLieu.TenNguyenLieu;
                nl.SoLuongHienCon = 0;
                nl.GhiChu = nguyenLieu.GhiChu;
                nl.GiaNhapCuoi = 0;
                nl.MaLNL_id = nguyenLieu.MaLNL_id;
                db.NguyenLieus.Add(nl);
                var loaiNguyenLieu = db.LoaiNguyenLieus.SingleOrDefault(n => n.MaLNL == nguyenLieu.MaLNL_id);
                loaiNguyenLieu.TongSoLuong++;
                db.SaveChanges();
                return RedirectToAction("ListNguyenLieu", "NguyenLieu");
            }

            ViewBag.MaLNL_id = new SelectList(db.LoaiNguyenLieus, "MaLNL", "TenLNL", nguyenLieu.MaLNL_id);
            return View(nguyenLieu);
        }

    }
}