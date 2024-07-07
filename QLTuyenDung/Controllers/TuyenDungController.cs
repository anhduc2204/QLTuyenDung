using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLTuyenDung.DAO;
using QLTuyenDung.Models;
using QLTuyenDung.Models.ViewModels;

namespace QLTuyenDung.Controllers
{
    public class TuyenDungController : Controller
    {

        private readonly ViecLamDAO _ViecLamDAO;
        private readonly NguoiDungDAO _NguoiDungDAO;
        private readonly UngTuyenDAO _UngTuyenDAO;

        public TuyenDungController(ViecLamDAO viecLamDAO, NguoiDungDAO nguoiDungDAO, UngTuyenDAO ungTuyenDAO)
        {
            _ViecLamDAO = viecLamDAO;
            _NguoiDungDAO = nguoiDungDAO;
            _UngTuyenDAO = ungTuyenDAO;
        }

        public async Task<IActionResult> Index()
        {
            
            var dsViecLam = await _ViecLamDAO.GetAll();
            return View(dsViecLam);
        }

        [HttpGet]
        public IActionResult UngTuyen()
        {
            var NDJson = HttpContext.Session.GetString("nguoiDung");

            if (NDJson == null)
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UngTuyen(UngTuyenViewModel model)
        {
            if (!ModelState.IsValid)
            {      
                return View(model);
            }
            
            var donUT = new DonUngTuyen
            {
                iMaND = model.MaND,
                iMaViecLam = model.MaViecLam,
                ViecLam = await _ViecLamDAO.GetByID(model.MaViecLam),
                NguoiDung = await _NguoiDungDAO.GetByID(model.MaND),
                MoTa = model.MoTa,
                
            };
            await _UngTuyenDAO.UngTuyen(donUT);

            return RedirectToAction("Index");
        }


    }
}
