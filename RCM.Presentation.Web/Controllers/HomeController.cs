using Microsoft.AspNetCore.Mvc;

namespace RCM.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}