using Microsoft.EntityFrameworkCore;
using QLTuyenDung.Models;

namespace QLTuyenDung.DAO
{
    public class NguoiDungDAO
    {
        private readonly DataContext _dataContext;

        public NguoiDungDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        
        public async Task<NguoiDung> getByUserNameAndPassWord(string taiKhoan, string matKhau)
        {
            var tk =  await _dataContext.DSTaiKhoan
                                        .Include(t => t.NguoiDung)
                                        .FirstOrDefaultAsync(t => t.TenTaiKhoan == taiKhoan && t.MatKhau == matKhau);

            return tk == null ? null : tk.NguoiDung;
            
         
        }
            
        


    }
}
