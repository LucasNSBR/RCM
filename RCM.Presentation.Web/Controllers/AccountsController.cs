using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Domain.Services.Email;
using RCM.Presentation.Web.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailGenerator _emailGenerator;
        private readonly IEmailDispatcher _emailDispatcher;

        #region OK
        public AccountsController(RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IDomainNotificationHandler domainNotificationHandler, IHttpContextAccessor httpContextAccessor, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
            _emailGenerator = emailGenerator;
            _emailDispatcher = emailDispatcher;
        }

        [UnallowAuthorized]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [UnallowAuthorized]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(registerViewModel);
            }

            var user = new RCMIdentityUser(registerViewModel.Email, registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.Age);
            var identityResult = await _rcmUserManager.CreateAsync(user, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
                var code = await _rcmUserManager.GenerateEmailConfirmationTokenAsync(user);
                await SendAccountConfirmationEmailAsync(user.Email, code);

                return RedirectToAction(nameof(ConfirmEmailSent));
            }
            else
                identityResult.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(loginViewModel);
            }
            
            var signInResult = await _rcmSignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.PersistentLogin, true);

            if (signInResult.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl);

                return RedirectToPlatform();
            }
            else if (signInResult.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(TwoFactorAuth));
            }
            else if(signInResult.IsLockedOut)
                return RedirectToAction(nameof(LockedOut));

            NotifyIdentityError("O usuário e/ou senha estão incorretos.");
            return View(loginViewModel);
        }

        [UnallowAuthorized]
        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        [UnallowAuthorized]
        [ValidateAntiForgeryToken]
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
                var code = await _rcmUserManager.GeneratePasswordResetTokenAsync(user);
                await SendResetPasswordEmailAsync(user.Email, code);

                return View(nameof(RecoverPasswordEmailSent));
            }
            else
            {
                NotifyIdentityError("Este e-mail não pertence a nenhum usuário.");
                return View(recoverPasswordViewModel);
            }
        }

        [NonAction]
        public IActionResult RecoverPasswordEmailSent()
        {
            return View();
        }

        [UnallowAuthorized]
        public IActionResult ResetPassword(string email = null, string code = null)
        {
            var resetViewModel = new ResetPasswordViewModel(email);
            return View(resetViewModel);
        }

        [HttpPost]
        [UnallowAuthorized]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(resetPasswordViewModel);
            }

            var user = await _rcmUserManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user != null)
            {
                var identityResult = await _rcmUserManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.ConfirmNewPassword);
                if (identityResult.Succeeded)
                    return RedirectToAction(nameof(Login));
                else
                {
                    identityResult.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));

                    return View(resetPasswordViewModel);
                }
            }
            else
            {
                NotifyIdentityError("Este e-mail não pertence a nenhum usuário. Confira novamente seu e-mail ou peça outro código de confirmação");
                return View(resetPasswordViewModel);
            }
        }

        public IActionResult ConfirmEmailSent(string email)
        {
            return View();
        }

        [UnallowAuthorized]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            var user = await _rcmUserManager.FindByEmailAsync(email);
            var result = await _rcmUserManager.ConfirmEmailAsync(user, code.Replace(" ", "+"));

            if (result.Succeeded)
                return RedirectToAction(nameof(Login));
            else
                throw new Exception("Ocorreu um erro ao tentar validar a conta. É necessário pedir um novo e-mail de confirmação");
        }

        [NonAction]
        public IActionResult LockedOut()
        {
            return View();
        }

        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var authProperties = _rcmSignInManager.ConfigureExternalAuthenticationProperties(provider, Url.Action(nameof(ExternalLoginCallback), new { provider, returnUrl }));
            return Challenge(authProperties, provider);
        }
        
        [UnallowAuthorized]
        public async Task<IActionResult> ExternalLoginCallback(string provider, string returnUrl = null)
        {
            var providerInfo = await _rcmSignInManager.GetExternalLoginInfoAsync();
            var result = await _rcmSignInManager.ExternalLoginSignInAsync(provider, providerInfo.ProviderKey, false);
            var user = await _rcmUserManager.FindByEmailAsync(providerInfo.Principal.FindFirst(c => c.Type == ClaimTypes.Email).Value);

            if (result.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                    return RedirectToPlatform();
            }
            else if (result.RequiresTwoFactor)
                return RedirectToAction(nameof(TwoFactorAuth));
            else if (result.IsLockedOut)
                return RedirectToAction(nameof(LockedOut));

            return RedirectToAction(nameof(ExternalLoginConfirmation));
        }

        [UnallowAuthorized]
        public IActionResult ExternalLoginConfirmation()
        {
            return View();
        }

        [UnallowAuthorized]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel confirmationViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(confirmationViewModel);
            }

            var providerInfo = await _rcmSignInManager.GetExternalLoginInfoAsync();
            var user = new RCMIdentityUser(providerInfo.Principal.FindFirst(ClaimTypes.Email).Value, confirmationViewModel.FirstName, confirmationViewModel.LastName, confirmationViewModel.Age);

            var result = await _rcmUserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var externalResult = await _rcmUserManager.AddLoginAsync(user, providerInfo);
                if (externalResult.Succeeded)
                {
                    var code = await _rcmUserManager.GenerateEmailConfirmationTokenAsync(user);
                    await SendAccountConfirmationEmailAsync(user.Email, code);

                    return RedirectToAction(nameof(ExternalLogin));
                }
                else
                    externalResult.Errors.ToList().ForEach(e => NotifyIdentityError(e.Description));
            }

            return View(confirmationViewModel);
        }

        [UnallowAuthorized]
        public async Task<IActionResult> TwoFactorAuth(string returnUrl = null)
        {
            var user = await _rcmSignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
                throw new Exception("Usuário não encontrado. É necessário ter um usuário válido.");
            else
            {
                var code = await _rcmUserManager.GenerateTwoFactorTokenAsync(user, "Email");
                await SendTwoFactorAuthenticationEmailAsync(user.Email, code);
            }

            TempData["returnUrl"] = returnUrl;
            return View();
        }
        #endregion


        [UnallowAuthorized]
        [HttpPost]
        public async Task<IActionResult> TwoFactorAuth(TwoFactorAuthViewModel twoFactorAuthViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(twoFactorAuthViewModel);
            }

            var result = await _rcmSignInManager.TwoFactorSignInAsync("Email", twoFactorAuthViewModel.Code, twoFactorAuthViewModel.PersistentLogin, twoFactorAuthViewModel.RememberClient);
            if (result.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                    return RedirectToPlatform();
            }
            else if(result.IsLockedOut)
                return RedirectToAction(nameof(LockedOut));

            return View(twoFactorAuthViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _rcmSignInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }

        #region Helpers
        private void NotifyIdentityError(string description = "")
        {
            _domainNotificationHandler.AddNotification(new AuthenticationErrorDomainNotification(description));
        }

        private Task SendAccountConfirmationEmailAsync(string email, string code)
        {
            var emailTemplate = _emailGenerator.GenerateAccountConfirmationEmail(email, code);
            return _emailDispatcher.SendEmailAsync(emailTemplate);
        }

        private Task SendResetPasswordEmailAsync(string email, string code)
        {
            var emailTemplate = _emailGenerator.GeneratePasswordResetEmail(email, code);
            return _emailDispatcher.SendEmailAsync(emailTemplate);
        }

        private Task SendTwoFactorAuthenticationEmailAsync(string email, string code)
        {
            var emailTemplate = _emailGenerator.GenerateTwoFactorAuthenticationEmail(email, code);
            return _emailDispatcher.SendEmailAsync(emailTemplate);
        }
        #endregion
    }
}