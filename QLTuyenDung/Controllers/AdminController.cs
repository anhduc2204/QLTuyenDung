using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;
using QLTuyenDung.Models;
using QLTuyenDung.Models.ViewModels;

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

        [HttpPost]
        [Route("ThemViecLam")]
        public async Task<IActionResult> ThemViecLam(ViecLamViewModel model)
        {
            if(!ModelState.IsValid || model.NgayHetHan <= model.NgayTao)
            {
                if(model.NgayHetHan <= model.NgayTao)
                {
                    ModelState.AddModelError("NgayHetHan", "Ngày hết hạn phải lớn hơn ngày tạo");
                    return View(model);
                }
            }
            var viecLam = new ViecLam
            {
                TieuDe = model.TieuDe,
                MoTa = model.MoTa,
                MucLuong = model.MucLuong,
                NgayTao = model.NgayTao,
                NgayHetHan = model.NgayHetHan,
                TrangThai = Convert.ToBoolean(model.TrangThai)
            };
            await _ViecLamdao.Save(viecLam);

            return RedirectToAction("QuanLyViecLam");
        }




    }
}
