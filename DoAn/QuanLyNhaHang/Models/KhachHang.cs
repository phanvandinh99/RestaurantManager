namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DatBan = new HashSet<DatBan>();
        }

        [Key]
        [StringLength(50)]
        public string TaiKhoanKH { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhauKH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatBan> DatBan { get; set; }
    }
}
