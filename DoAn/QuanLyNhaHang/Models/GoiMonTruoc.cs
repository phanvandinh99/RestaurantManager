namespace QuanLyNhaHang.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GoiMonTruoc")]
    public partial class GoiMonTruoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiMonTruoc()
        {
            DatBan = new HashSet<DatBan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGoiMonTruoc { get; set; }

        public int SoLuong { get; set; }

        public double? DonGia { get; set; }

        public int? MaMonAn_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatBan> DatBan { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
