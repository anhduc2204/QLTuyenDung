using Microsoft.EntityFrameworkCore;
using QLTuyenDung.Models;

namespace QLTuyenDung.DAO
{
    public class TaiKhoanDAO
    {
        private readonly DataContext _dataContext;

        public TaiKhoanDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<TaiKhoan> getByUserNameAndPassWord(string taiKhoan, string matKhau)
        {
            var tk = await _dataContext.DSTaiKhoan
                                        .Include(t => t.NguoiDung)
                                        .Include(t => t.QuyenHan)
                                        .FirstOrDefaultAsync(t => t.TenTaiKhoan == taiKhoan && t.MatKhau == matKhau);

            return tk;
        }

    }
}
