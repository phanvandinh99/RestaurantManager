namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("XuatKho")]
    public partial class XuatKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XuatKho()
        {
            NguyenLieuXuat = new HashSet<NguyenLieuXuat>();
        }

        [Key]
        public int MaXuatKho { get; set; }

        public DateTime? NgayXuat { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuXuat> NguyenLieuXuat { get; set; }
    }
}
