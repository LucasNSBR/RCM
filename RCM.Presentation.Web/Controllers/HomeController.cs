using Microsoft.AspNetCore.Mvc;

namespace RCM.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            if(statusCode != null)
            {
                return View();
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}