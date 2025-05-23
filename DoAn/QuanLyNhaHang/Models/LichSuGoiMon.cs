namespace QuanLyNhaHang.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LichSuGoiMon")]
    public partial class LichSuGoiMon
    {
        [Key]
        public int MaLichSu { get; set; }

        public int SoLuongMua { get; set; }

        public int? SoLuongTra { get; set; }

        public DateTime? ThoiGianGoi { get; set; }

        public DateTime? ThoiGianTra { get; set; }

        public int? MaHoaDon_id { get; set; }

        public int? MaMonAn_id { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
