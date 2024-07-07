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

        public async Task<TaiKhoan> Save(TaiKhoan taiKhoan)
        {
            var tk = await _dataContext.DSTaiKhoan.AddAsync(taiKhoan);
            await _dataContext.SaveChangesAsync();
            
            if (tk != null && tk.State == EntityState.Added)
            {
                // Đối tượng TaiKhoan đã được thêm và lưu xuống cơ sở dữ liệu
                return tk.Entity;
            }
            else
            {
                // Xử lý khi không thể thêm hoặc lưu đối tượng TaiKhoan
                throw new InvalidOperationException("Không thể thêm hoặc lưu đối tượng TaiKhoan.");
            }
        }

    }
}
