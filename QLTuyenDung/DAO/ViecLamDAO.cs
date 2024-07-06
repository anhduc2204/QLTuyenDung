using Microsoft.EntityFrameworkCore;
using QLTuyenDung.Models;

namespace QLTuyenDung.DAO
{
    public class ViecLamDAO
    {
        private readonly DataContext _dataContext;

        public ViecLamDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ViecLam>> GetAll()
        {
            return await _dataContext.DSViecLam
                .Include(vl => vl.DSDonUT)
                .ToListAsync<ViecLam>();
        }

    }
}
