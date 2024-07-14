using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var ndjson = HttpContext.Session.GetString("NguoiDung");

            if (ndjson == null)
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            var nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(ndjson);
            var quyen = HttpContext.Session.GetString("QuyenHan");
            if (quyen == null || !quyen.Equals("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            var dsViecLam = await _ViecLamdao.GetAll();
            return View("~/Views/Admin/QuanLyViecLam.cshtml",dsViecLam);
        }

        [HttpGet]
        [Route("ThemViecLam")]
        public IActionResult ThemViecLam()
        {
            var ndjson = HttpContext.Session.GetString("NguoiDung");

            if (ndjson == null)
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            var nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(ndjson);
            var quyen = HttpContext.Session.GetString("QuyenHan");
            if (quyen == null || !quyen.Equals("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
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

		[HttpGet]
		[Route("ThongBao")]
		public IActionResult ThongBao()
		{
			/*var ndjson = HttpContext.Session.GetString("NguoiDung");
			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}*/
			return View();
		}

        [HttpPost]
        [Route("ThongBao")]
        public async Task<IActionResult> ThongBao(ThongBaoViewModel model)
        {
            int check = await Utils.MailUtils.GuiThongBao(model.ToEmail.Trim(), model.Subject.Trim(), model.Message.Trim());
            ViewBag.MessageCode = check;
            if(check == 1)
            {
                ViewBag.Message = "Gửi thành công";
            }
            else
            {
                ViewBag.Message = "Gửi thất bại";
            }
            return View(model);
        }

    }
}
