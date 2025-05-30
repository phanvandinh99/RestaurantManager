namespace QuanLyNhaHang.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GoiMonTruoc")]
    public partial class GoiMonTruoc
    {
        [Key]
        public int MaGoiMonTruoc { get; set; }

        public int SoLuong { get; set; }

        public double? DonGia { get; set; }

        public int? MaMonAn_id { get; set; }

        public int? MaDatBan_id { get; set; }

        public virtual DatBan DatBan { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
