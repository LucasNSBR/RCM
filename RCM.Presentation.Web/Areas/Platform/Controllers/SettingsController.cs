using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> MyProfile()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var profileViewModel = new ProfileViewModel(user);

            return View(profileViewModel);
        }

        public async Task<IActionResult> EditMyProfile(int id)
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var profileViewModel = new ProfileViewModel(user);

            return View(profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyProfile(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(profileViewModel);
            }

            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var result = await _rcmUserManager.ChangeBasicInfoAsync(user, profileViewModel.FirstName, profileViewModel.LastName, profileViewModel.Age);

            if (result.Succeeded)
                return RedirectToAction(nameof(DuplicatasController.Index), "Duplicatas");
            else
                result.Errors.ToList().ForEach(e => AddIdentityError(e.Description));

            return View(profileViewModel);
        }

        public async Task<IActionResult> Manage()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var settingsViewModel = new ManageViewModel();

            return View(settingsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageViewModel settingsViewModel)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(settingsViewModel);
            }

            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var result = await _rcmUserManager.UpdateAsync(user);

            return View(user);
        }

        private void AddIdentityError(string description = "")
        {
            _domainNotificationHandler.AddNotification(new AuthenticationErrorDomainNotification(description));
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(changePasswordViewModel);
            }

            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var result = await _rcmUserManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);

            if (result.Succeeded)
                return RedirectToAction(nameof(Manage));
            else
                result.Errors.ToList().ForEach(e => AddIdentityError(e.Description));

            return View(changePasswordViewModel);
        }

        public async Task<IActionResult> EnableTwoFactorAuthentication()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var result = await _rcmUserManager.SetTwoFactorEnabledAsync(user, true);

            if (result.Succeeded)
                return RedirectToAction(nameof(Manage));
            else
                result.Errors.ToList().ForEach(e => AddIdentityError(e.Description));

            return RedirectToAction(nameof(Manage));
        }
    }
}