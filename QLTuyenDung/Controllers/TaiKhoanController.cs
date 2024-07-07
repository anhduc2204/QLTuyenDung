﻿using Microsoft.AspNetCore.Mvc;
using QLTuyenDung.DAO;
using QLTuyenDung.Models;
using Newtonsoft.Json;
using QLTuyenDung.Models.ViewModels;

namespace QLTuyenDung.Controllers
{
    public class TaiKhoanController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly NguoiDungDAO _NDdao;
        private readonly TaiKhoanDAO _TaiKhoanDAO;

        public TaiKhoanController(NguoiDungDAO nguoiDungDAO, TaiKhoanDAO taiKhoanDAO)
        {
            _NDdao = nguoiDungDAO;
            _TaiKhoanDAO = taiKhoanDAO;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            string email = loginViewModel.Email.Trim();
            string matKhau = loginViewModel.MatKhau.Trim();
            if(email == "" || matKhau == "")
            {
                return ViewBag.Message = "Yêu cầu nhập đầy đủ thông tin!"; 
            }
            var tk = await Authenticate(email, matKhau);
            if (tk != null)
            {
                
            }  

            return View();
 
             
        }

        public IActionResult DangNhap(TaiKhoan tk)
        {
            NguoiDung nd = tk.NguoiDung;
            var ndJson = JsonConvert.SerializeObject(nd, Formatting.None,
                                        new JsonSerializerSettings()
                                        {
                                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                        });
            HttpContext.Session.SetString("NguoiDung", ndJson);
            HttpContext.Session.SetString("QuyenHan", tk.QuyenHan.TenQuyen);
            if (tk.QuyenHan.TenQuyen.Equals("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            string hoTen = registerViewModel.HoTen.Trim();
            string email = registerViewModel.Email.Trim();
            string matKhau = registerViewModel.MatKhau.Trim();

            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
                ViewBag.Message = "Không hợp lệ";
            }

            TaiKhoan tk = new TaiKhoan
            {
                TenTaiKhoan = registerViewModel.Email,
                MatKhau = registerViewModel.MatKhau,
                QuyenHan = new QuyenHan{ MaQuyen = 1 },
                NguoiDung = new NguoiDung
                {
                    Email = registerViewModel.Email,
                    TenND = registerViewModel.HoTen
                }
                
            };
            var tkCheck = _TaiKhoanDAO.Save(tk);
            if(tkCheck == null)
            {
                ViewBag.Message = "Không thành công, thử lại sau!";
                return View(registerViewModel);
            }
            return View();
           
        }

        public Task<TaiKhoan> Authenticate(string email, string matKhau)
        {
            return _TaiKhoanDAO.getByUserNameAndPassWord(email, matKhau);
            
        }

        

    }
}
