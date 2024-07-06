using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;

namespace QLTuyenDung.Controllers
{
    public class AdminController : Controller
    {
        private readonly ViecLamDAO _ViecLamdao;

        public AdminController(ViecLamDAO viecLamDAO)
        {
            _ViecLamdao = viecLamDAO;
        }

        [HttpGet]
        [Route("Admin/")]
        public async Task<IActionResult> QuanLyViecLam()
        {
            var dsViecLam = await _ViecLamdao.GetAll();
            return View("~/Views/Admin/QuanLyViecLam.cshtml",dsViecLam);
        }



    }
}
