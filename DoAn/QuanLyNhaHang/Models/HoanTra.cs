namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HoanTra")]
    public partial class HoanTra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoanTra()
        {
            NguyenLieuTras = new HashSet<NguyenLieuTra>();
        }

        [Key]
        public int MaHoanTra { get; set; }

        public DateTime? NgayHoanTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuTra> NguyenLieuTras { get; set; }
    }
}
