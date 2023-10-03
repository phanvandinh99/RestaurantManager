﻿using QuanLyNhaHang.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.Entity;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class NhanVienController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DSNhanVien()
        {
            var list = db.NhanViens.Where(n=>n.MaQuyen_id==1).OrderBy(n => n.MaQuyen_id).ToList();
            return View(list);
        }
        public ActionResult DSNhanVienKho()
        {
            var list = db.NhanViens.Where(n => n.MaQuyen_id == 2).OrderBy(n => n.MaQuyen_id).ToList();
            return View(list);
        }
        public ActionResult ThemNhanVien()
        {
            ViewBag.Quyen = db.Quyens.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ThemNhanVien(QuanLyNhaHang.Models.NhanVien Model)
        {
            db.NhanViens.Add(Model);
            db.SaveChanges();
            return RedirectToAction("DSNhanVien", "NhanVien");
        }
        public ActionResult Xoa(string sTaiKhoanid)
        {
            var nhanVien = db.NhanViens.Find(sTaiKhoanid);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("DSNhanVien", "NhanVien");
        }
        public ActionResult XemChiTiet(string sTaiKhoanid)
        {
            var nhanVien = db.NhanViens.Find(sTaiKhoanid);
            return View(nhanVien);
        }
        public ActionResult CapNhat(string sTaiKhoanid)
        {
            QuanLyNhaHang.Models.NhanVien nhanVien = db.NhanViens.Find(sTaiKhoanid);
            ViewBag.MaQuyen_id = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", nhanVien.MaQuyen_id);
            return View(nhanVien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhat([Bind(Include = "TaiKhoanNV,MatKhauNV,TenNhanVien,NgaySinh,SoDienThoai,MaQuyen_id")] QuanLyNhaHang.Models.NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSNhanVien", "NhanVien");
            }
            ViewBag.MaQuyen_id = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", nhanVien.MaQuyen_id);
            return View();
        }
    }
}