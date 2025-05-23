namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ban")]
    public partial class Ban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ban()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaBan { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBan { get; set; }

        public int SoGhe { get; set; }

        public int? Vip { get; set; }

        public int? TinhTrang { get; set; }

        public int? MaTang_id { get; set; }

        public virtual Tang Tang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
