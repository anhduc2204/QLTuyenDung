using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;
using QLTuyenDung.Models;
using Newtonsoft.Json;

namespace QLTuyenDung.Controllers
{
    public class TaiKhoanController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly NguoiDungDAO _NDdao;

        public TaiKhoanController(NguoiDungDAO nguoiDungDAO)
        {
            _NDdao = nguoiDungDAO;
        }

        [HttpGet]
        public IActionResult ToLogin()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string email = Request.Form["email"].ToString().Trim();
            string matKhau = Request.Form["matKhau"].ToString().Trim();
            if(email == "" || matKhau == "")
            {
                return ViewBag.Message = "Yêu cầu nhập đầy đủ thông tin!"; 
            }
            NguoiDung nd = await Authenticate(email, matKhau);
            if (nd != null)
            {
                var NDJson = JsonConvert.SerializeObject(nd);
                HttpContext.Session.SetString("nguoiDung", NDJson);
                return RedirectToAction("Index", "Home");
            }  

            return View();
 
             
        }

        [HttpGet]
        public IActionResult ToRegister()
        {
            return View();
        } 

        public Task<NguoiDung> Authenticate(string email, string matKhau)
        {
            return _NDdao.getByUserNameAndPassWord(email, matKhau);
            
        }

        

    }
}
