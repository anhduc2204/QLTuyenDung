using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace QLTuyenDung.Models
{
    [Table("tbl_NguoiDung")]
    public class NguoiDung
    {
      
       [ Column("iMaND"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
       
        public int MaND { get; set; }

       [Column("sTenND"), Required, StringLength(50)]
        public string TenND { set; get; }

        [Column("sEmail"), Required, StringLength(50)]
        public string Email {set; get;}

        [Column("sSDT"), StringLength(15)]
        public string? SDT {  set; get; }

       [Column("dNgaySinh")]
        public DateTime? NgaySinh { set; get; }

       [Column("sGioiTinh"), StringLength(10)]
        public string? GioiTinh {  set; get; }
        [JsonIgnore]
        [ForeignKey("iMaTaiKhoan"), Required]
        
        public int iMaTaiKhoan { get; set; }

      
      //  public TaiKhoan TaiKhoan { get; set; }



    }
}
