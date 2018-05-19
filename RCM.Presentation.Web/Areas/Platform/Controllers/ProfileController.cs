using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Presentation.Web.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class ProfileController : BaseController
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ProfileController(IDomainNotificationHandler domainNotificationHandler, RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IHttpContextAccessor httpContextAccessor) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var profileViewModel = await GetProfileAsync();
            return View(profileViewModel);
        }

        public async Task<IActionResult> Edit()
        {
            var profileViewModel = await GetProfileAsync();
            return View(profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(profileViewModel);
            }

            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var result = await _rcmUserManager.ChangeBasicInfoAsync(user, profileViewModel.FirstName, profileViewModel.LastName, profileViewModel.Age);

            if (result.Succeeded)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                result.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

            return View(profileViewModel);
        }

        #region Helpers
        private async Task<ProfileViewModel> GetProfileAsync()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return new ProfileViewModel(user);
        }
        #endregion
    }
}