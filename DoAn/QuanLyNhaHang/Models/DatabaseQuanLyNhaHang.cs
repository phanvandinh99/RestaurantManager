using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhaHang.Models
{
    public partial class DatabaseQuanLyNhaHang : DbContext
    {
        public DatabaseQuanLyNhaHang()
            : base("name=DatabaseQuanLyNhaHang")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoanTra> HoanTras { get; set; }
        public virtual DbSet<LichSuGoiMon> LichSuGoiMons { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieus { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<NguyenLieuTra> NguyenLieuTras { get; set; }
        public virtual DbSet<NguyenLieuXuat> NguyenLieuXuats { get; set; }
        public virtual DbSet<NhaCC> NhaCCs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomMonAn> NhomMonAns { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<Tang> Tangs { get; set; }
        public virtual DbSet<XuatKho> XuatKhoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.Ban)
                .HasForeignKey(e => e.MaBan_id);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.MaHoaDon_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.LichSuGoiMons)
                .WithOptional(e => e.HoaDon)
                .HasForeignKey(e => e.MaHoaDon_id);

            modelBuilder.Entity<HoanTra>()
                .HasMany(e => e.NguyenLieuTras)
                .WithRequired(e => e.HoanTra)
                .HasForeignKey(e => e.MaHoanTra_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMonAn>()
                .HasMany(e => e.MonAns)
                .WithOptional(e => e.LoaiMonAn)
                .HasForeignKey(e => e.MaLMA_id);

            modelBuilder.Entity<LoaiNguyenLieu>()
                .HasMany(e => e.NguyenLieux)
                .WithOptional(e => e.LoaiNguyenLieu)
                .HasForeignKey(e => e.MaLNL_id);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietSanPhams)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.LichSuGoiMons)
                .WithOptional(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ChiTietPhieuNhaps)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ChiTietSanPhams)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.NguyenLieuXuats)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.NguyenLieuTras)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .HasMany(e => e.PhieuNhaps)
                .WithOptional(e => e.NhaCC)
                .HasForeignKey(e => e.MaNCC_id);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhauNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuNhaps)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.TaiKhoanNV_id);

            modelBuilder.Entity<NhomMonAn>()
                .HasMany(e => e.MonAns)
                .WithOptional(e => e.NhomMonAn)
                .HasForeignKey(e => e.MaNMA_id);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TaiKhoanNV_id)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .HasForeignKey(e => e.MaPhieuNhap_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.Quyen)
                .HasForeignKey(e => e.MaQuyen_id);

            modelBuilder.Entity<Tang>()
                .HasMany(e => e.Bans)
                .WithOptional(e => e.Tang)
                .HasForeignKey(e => e.MaTang_id);

            modelBuilder.Entity<XuatKho>()
                .HasMany(e => e.NguyenLieuXuats)
                .WithRequired(e => e.XuatKho)
                .HasForeignKey(e => e.MaXuatKho_id)
                .WillCascadeOnDelete(false);
        }
    }
}
