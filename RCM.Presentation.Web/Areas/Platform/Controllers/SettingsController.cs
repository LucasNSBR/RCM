using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Domain.Services.Email;
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
        private readonly IEmailGenerator _emailGenerator;
        private readonly IEmailDispatcher _emailDispatcher;

        public SettingsController(IDomainNotificationHandler domainNotificationHandler, RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IHttpContextAccessor httpContextAccessor, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
            _emailGenerator = emailGenerator;
            _emailDispatcher = emailDispatcher;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var viewModel = new ManageViewModel()
            {
                ConfirmedEmail = await _rcmUserManager.IsEmailConfirmedAsync(user),
                TwoFactorActivated = await _rcmUserManager.GetTwoFactorEnabledAsync(user),
                Roles = await _rcmUserManager.GetRolesAsync(user)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> SendConfirmEmail()
        {
            var user = await GetUserAsync();
            var code = await _rcmUserManager.GenerateEmailConfirmationTokenAsync(user);
            await SendAccountConfirmationEmailAsync(user.Email, code);

            return RedirectToAction(nameof(ConfirmEmailSent));
        }

        public IActionResult ConfirmEmailSent(string email)
        {
            return View();
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

            var user = await GetUserAsync();
            var result = await _rcmUserManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            else
                result.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

            return View(changePasswordViewModel);
        }

        public async Task<IActionResult> EnableTwoFactorAuth()
        {
            var user = await GetUserAsync();
            var result = await _rcmUserManager.SetTwoFactorEnabledAsync(user, enabled: true);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            else
                result.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DisableTwoFactorAuth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableTwoFactorAuth(DisableTwoFactorAuthViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(viewModel);
            }

            var user = await GetUserAsync();
            var canDisable = await _rcmUserManager.GenerateUserTokenAsync(user, "Disable2FA", "This token will disable two factor auth");
            //if (!canDisable.Succeeded)
            //{
            //    NotifyIdentityError("Houve um erro ao validar sua tentativa, tente novamente.");
            //    return View(viewModel);
            //}

            var result = await _rcmUserManager.SetTwoFactorEnabledAsync(user, enabled: false);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            else
                result.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

            return RedirectToAction(nameof(Index));
        }

        #region Helpers
        private async Task<RCMIdentityUser> GetUserAsync()
        {
            var user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
        }

        private Task SendAccountConfirmationEmailAsync(string email, string code)
        {
            var emailTemplate = _emailGenerator.GenerateAccountConfirmationEmail(email, code);
            return _emailDispatcher.SendEmailAsync(emailTemplate);
        }

        private void NotifyIdentityError(string description)
        {
            _domainNotificationHandler.AddNotification(new AuthenticationErrorNotification(description));
        }
        #endregion
    }
}