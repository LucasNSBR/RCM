using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.ViewComponents
{
    public class UserInformationViewComponent : ViewComponent
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInformationViewComponent(RCMUserManager rcmUserManager, IHttpContextAccessor httpContextAccessor)
        {
            _rcmUserManager = rcmUserManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                return View(user);
            }

            return View("NotLogged");
        }
    }
}
