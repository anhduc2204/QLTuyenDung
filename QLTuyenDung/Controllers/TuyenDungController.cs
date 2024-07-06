using Microsoft.AspNetCore.Mvc;

namespace QLTuyenDung.Controllers
{
    public class TuyenDungController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
