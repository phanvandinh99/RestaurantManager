namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieu()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            NguyenLieuXuats = new HashSet<NguyenLieuXuat>();
            NguyenLieuTras = new HashSet<NguyenLieuTra>();
        }

        [Key]
        public int MaNguyenLieu { get; set; }

        [Required]
        [StringLength(200)]
        public string TenNguyenLieu { get; set; }

        public double? SoLuongHienCon { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public double GiaNhapCuoi { get; set; }

        public int? MaLNL_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public virtual LoaiNguyenLieu LoaiNguyenLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuXuat> NguyenLieuXuats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuTra> NguyenLieuTras { get; set; }
    }
}
