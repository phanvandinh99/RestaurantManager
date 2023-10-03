namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieuTra")]
    public partial class NguyenLieuTra
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoanTra_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNguyenLieu_id { get; set; }

        public double? SoLuongTra { get; set; }


        public virtual HoanTra HoanTra { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
