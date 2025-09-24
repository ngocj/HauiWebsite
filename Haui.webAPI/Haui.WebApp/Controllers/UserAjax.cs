using Microsoft.AspNetCore.Mvc;

namespace Haui.WebApp.Controllers
{
    public class UserAjax : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
