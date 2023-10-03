using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class HoaDonsController : Controller
    {
        private DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();

        // GET: NhanVien/HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.Ban);
            return View(hoaDons.ToList());
        }

        // GET: NhanVien/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: NhanVien/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaBan_id = new SelectList(db.Bans, "MaBan", "TenBan");
            return View();
        }

        // POST: NhanVien/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,TenKhachHang,SDTKhachHang,TongHoaDon,NgayTao,NgayThanhToan,GhiChu,TongTien,TrangThai,MaBan_id")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBan_id = new SelectList(db.Bans, "MaBan", "TenBan", hoaDon.MaBan_id);
            return View(hoaDon);
        }

        // GET: NhanVien/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBan_id = new SelectList(db.Bans, "MaBan", "TenBan", hoaDon.MaBan_id);
            return View(hoaDon);
        }

        // POST: NhanVien/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,TenKhachHang,SDTKhachHang,TongHoaDon,NgayTao,NgayThanhToan,GhiChu,TongTien,TrangThai,MaBan_id")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBan_id = new SelectList(db.Bans, "MaBan", "TenBan", hoaDon.MaBan_id);
            return View(hoaDon);
        }

        // GET: NhanVien/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: NhanVien/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
