using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class SettingsController : BaseController
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SettingsController(IDomainNotificationHandler domainNotificationHandler, RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IHttpContextAccessor httpContextAccessor) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return View(user);
        }

        public async Task<IActionResult> Settings()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var profileViewModel = new ProfileViewModel(user);

            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(ProfileViewModel profileViewModel)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(profileViewModel);
            }

            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var result = await _rcmUserManager.UpdateAsync(user);

            return View(user);
        }
    }
}