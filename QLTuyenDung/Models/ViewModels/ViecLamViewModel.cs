using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTuyenDung.Models.ViewModels
{
    public class ViecLamViewModel
    {
        public string TieuDe { get; set; }

        
        public string MoTa { get; set; }

       
        public float MucLuong { get; set; }

        
        public DateTime NgayTao { get; set; }

        public DateTime NgayHetHan { get; set; }

    }
}
