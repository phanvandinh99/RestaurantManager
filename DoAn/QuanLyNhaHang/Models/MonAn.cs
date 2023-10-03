namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            LichSuGoiMons = new HashSet<LichSuGoiMon>();
        }

        [Key]
        public int MaMonAn { get; set; }

        [Required]
        [StringLength(255)]
        public string TenMonAn { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        public double? DonGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public string ThongTin { get; set; }

        public string MoTa { get; set; }

        public int? SoLuongDaBan { get; set; }

        public int? MaNMA_id { get; set; }

        public int? MaLMA_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuGoiMon> LichSuGoiMons { get; set; }

        public virtual LoaiMonAn LoaiMonAn { get; set; }

        public virtual NhomMonAn NhomMonAn { get; set; }
    }
}
