namespace QuanLyNhaHang.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LoaiMonAn")]
    public partial class LoaiMonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiMonAn()
        {
            MonAns = new HashSet<MonAn>();
        }

        [Key]
        public int MaLMA { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLMA { get; set; }

        public int? TongSoLuong{ get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn> MonAns { get; set; }
    }
}
