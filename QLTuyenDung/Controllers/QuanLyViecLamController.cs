using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;

namespace QLTuyenDung.Controllers
{
    public class QuanLyViecLamController : Controller
    {
        private readonly ViecLamDAO _ViecLamdao;

        public QuanLyViecLamController(ViecLamDAO viecLamDAO)
        {
            _ViecLamdao = viecLamDAO;
        }

        public async Task<IActionResult> Index()
        {
            var dsViecLam = await _ViecLamdao.GetAll();
            return View(dsViecLam);
        }



    }
}
