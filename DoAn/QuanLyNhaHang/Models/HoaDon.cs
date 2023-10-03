namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            LichSuGoiMons = new HashSet<LichSuGoiMon>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }
        public string SDTKhachHang { get; set; }
        public int? TongHoaDon { get; set; }
        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public double TongTien { get; set; }

        public int? TrangThai { get; set; }

        public int? MaBan_id { get; set; }

        public virtual Ban Ban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuGoiMon> LichSuGoiMons { get; set; }
    }
}
