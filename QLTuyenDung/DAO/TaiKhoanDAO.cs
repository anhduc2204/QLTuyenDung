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
            return await _dataContext.DSTaiKhoan
                                     .Include(t => t.NguoiDung)
                                     .Include(t => t.QuyenHan)
                                     .FirstOrDefaultAsync(t => t.TenTaiKhoan == taiKhoan && t.MatKhau == matKhau);
        }

        public async Task<TaiKhoan> Save(TaiKhoan taiKhoan)
        {
            var tk = await _dataContext.DSTaiKhoan.AddAsync(taiKhoan);
            await _dataContext.SaveChangesAsync();
            return tk.Entity;
        }

        public async Task<TaiKhoan> getByEmail(string email)
        {
            return await _dataContext.DSTaiKhoan.FirstOrDefaultAsync(t => t.TenTaiKhoan == email);
        }
    }

}
