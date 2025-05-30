namespace QuanLyNhaHang.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DatBan")]
    public partial class DatBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDatBan { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime? ThoiGianKetThuc { get; set; }

        public int SoNguoi { get; set; }

        public double? TongTienTamTinh { get; set; }

        public double? SoTienCoc { get; set; }

        public int? TrangThai { get; set; }

        public int? MaBan_id { get; set; }

        [StringLength(50)]
        public string TaiKhoanKH_id { get; set; }

        public int? MaGoiMonTruoc_id { get; set; }

        public virtual GoiMonTruoc GoiMonTruoc { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
