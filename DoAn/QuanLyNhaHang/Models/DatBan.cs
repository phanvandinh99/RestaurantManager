namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DatBan")]
    public partial class DatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatBan()
        {
            GoiMonTruoc = new HashSet<GoiMonTruoc>();
        }

        [Key]
        public int MaDatBan { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime? ThoiGianKetThuc { get; set; }

        public int SoNguoi { get; set; }

        public double? TongTienTamTinh { get; set; }

        public double? SoTienCoc { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public int? MaBan_id { get; set; }

        [StringLength(50)]
        public string TaiKhoanKH_id { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoiMonTruoc> GoiMonTruoc { get; set; }
    }
}
