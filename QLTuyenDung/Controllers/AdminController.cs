using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;

namespace QLTuyenDung.Controllers
{
    [Route("Admin/")]
    public class AdminController : Controller
    {
        private readonly ViecLamDAO _ViecLamdao;

        public AdminController(ViecLamDAO viecLamDAO)
        {
            _ViecLamdao = viecLamDAO;
        }

        [HttpGet]
        [Route("QuanLyViecLam")]
        [Route("")]
        public async Task<IActionResult> QuanLyViecLam()
        {
            var dsViecLam = await _ViecLamdao.GetAll();
            return View("~/Views/Admin/QuanLyViecLam.cshtml",dsViecLam);
        }

        [HttpGet]
        [Route("ThemViecLam")]
        public IActionResult ThemViecLam()
        {
            return View("~/Views/Admin/ThemViecLam.cshtml");
        }


    }
}
