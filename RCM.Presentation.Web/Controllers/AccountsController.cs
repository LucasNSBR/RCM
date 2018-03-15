using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Presentation.Web.Areas.Platform.Controllers;
using RCM.Presentation.Web.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsController(RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IDomainNotificationHandler domainNotificationHandler, IHttpContextAccessor httpContextAccessor) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [UnallowAuthorized]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [UnallowAuthorized]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(registerViewModel);
            }

            var identityUser = new RCMIdentityUser(registerViewModel.Email, registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.Age);
            var identityResult = await _rcmUserManager.CreateAsync(identityUser, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
                var code = await _rcmUserManager.GenerateEmailConfirmationTokenAsync(identityUser);
                return RedirectToAction(nameof(Login));
            }
            else
                identityResult.Errors.ToList().ForEach(e => AddIdentityError(e.Description));

            return View(registerViewModel);
        }

        [UnallowAuthorized]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [UnallowAuthorized]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(loginViewModel);
            }

            var user = await _rcmUserManager.FindByEmailAsync(loginViewModel.Email);
            var result = await _rcmSignInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberLogin, false);

            if (result.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                    return RedirectToAction(nameof(DuplicatasController.Index), "Duplicatas", new { area = "Platform" });
            }
            else if (result.RequiresTwoFactor)
                return RedirectToAction(nameof(TwoFactorAuthentication));
            else if (result.IsLockedOut)
                return RedirectToAction(nameof(LockedOut));
            else if (result.IsNotAllowed)
            {
                var code = await _rcmUserManager.GenerateEmailConfirmationTokenAsync(user);
                return RedirectToAction(nameof(ConfirmEmail), new { email = loginViewModel.Email });
            }

            return View(loginViewModel);
        }
        
        [UnallowAuthorized]
        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        [UnallowAuthorized]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordViewModel recoverPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(recoverPasswordViewModel);
            }

            var user = await _rcmUserManager.FindByEmailAsync(recoverPasswordViewModel.Email);

            if (user != null)
            {
                var result = await _rcmUserManager.GeneratePasswordResetTokenAsync(user);
                return View(result);
            }
            else
            {
                AddIdentityError("Este e-mail não pertence a nenhum usuário.");
                return View(recoverPasswordViewModel);
            }
        }

        [UnallowAuthorized]
        public IActionResult LockedOut()
        {
            return View();
        }

        [UnallowAuthorized]
        public IActionResult ConfirmEmail(string email = null)
        {
            var confirmEmailViewModel = new ConfirmEmailViewModel(email);
            return View(confirmEmailViewModel);
        }

        [HttpPost]
        [UnallowAuthorized]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel confirmEmailViewModel)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(confirmEmailViewModel);
            }

            var user = await _rcmUserManager.FindByEmailAsync(confirmEmailViewModel.Email);
            var result = await _rcmUserManager.ConfirmEmailAsync(user, confirmEmailViewModel.Code);

            if (result.Succeeded)
                return RedirectToAction(nameof(Login));
            else
                result.Errors.ToList().ForEach(e => AddIdentityError(e.Description));

            return View(confirmEmailViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _rcmSignInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }

        public IActionResult TwoFactorAuthentication()
        {
            return View();
        }

        private void AddIdentityError(string description = "")
        {
            _domainNotificationHandler.AddNotification(new AuthenticationErrorDomainNotification(description));
        }
    }
}