using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTuyenDung.Models.ViewModels
{
    public class ViecLamViewModel
    {
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public string MoTa { get; set; }

        
        [Range(1, float.MaxValue, ErrorMessage = "Mức lương không hợp lệ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Mức lương không hợp lệ")]
        public float MucLuong { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Ngày không hợp lệ")]
        public DateTime NgayTao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Ngày không hợp lệ")]
        public DateTime NgayHetHan { get; set; }

        public int TrangThai { get; set; }

    }
}
