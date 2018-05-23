using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.CrossCutting.Identity.Models;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.ViewModels;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "ActiveUser")]
    [Area("Platform")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaApplicationService _empresaApplicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;

        private RCMIdentityUser _user;

        public EmpresaController(IEmpresaApplicationService empresaApplicationService, IHttpContextAccessor httpContextAccessor, RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _empresaApplicationService = empresaApplicationService;
            _httpContextAccessor = httpContextAccessor;
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
        }

        public IActionResult Unattached()
        {
            return View();
        }

        public IActionResult Details()
        {
            var empresa = _empresaApplicationService.Get();
            if (empresa == null)
                return RedirectToAction(nameof(Unattached));

            return View(empresa);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Update()
        {
            var empresa = _empresaApplicationService.Get();
            if (empresa == null)
                return View();

            return View(empresa);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmpresaViewModel empresa)
        {
            if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return View(empresa);
                }

            var commandResult = await _empresaApplicationService.AddOrUpdate(empresa);

            if (commandResult.Success)
            {
                if (!_httpContextAccessor.HttpContext.User.HasClaim(c => c.Type == "ActiveCompany"))
                {
                    _user = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                    var result = await _rcmUserManager.AddClaimAsync(_user, new Claim("ActiveCompany", "True"));
                    if (result.Succeeded)
                    {
                        await _rcmSignInManager.RefreshSignInAsync(_user);
                    }
                    else
                    {
                        NotifyIdentityErrors(result);
                        return View(empresa);
                    }
                }

                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(empresa);
        }

        [Authorize(Policy = "ActiveUser")]
        [Authorize(Policy = "ActiveCompany")]
        public IActionResult AttachLogo()
        {
            var empresa = _empresaApplicationService.Get();
            if (empresa == null)
                return NotFound();

            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [Authorize(Policy = "ActiveCompany")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttachLogo(FormFile formFile)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(formFile);
            }

            byte[] logo;

            try
            {
                using(var memoryStream = new MemoryStream())
                {
                    var contentType = formFile.File.ContentType;
                    var size = formFile.File.Length;

                    if (formFile.File.Length > (3 * 1024 * 1024))
                        throw new ArgumentException("O tamanho do arquivo deve ser de até 3MB.");
                    if (contentType != "image/jpeg" && contentType != "image/jpg" && contentType != "image/png")
                        throw new ArgumentException("Arquivo deve estar em um formato inválido (jpg, jpeg ou png).");

                    await formFile.File.CopyToAsync(memoryStream);
                    logo = memoryStream.ToArray();
                }
            }
            catch(Exception e)
            {
                NotifyError(e.Message);
                return View(formFile);
            }

            var commandResult = await _empresaApplicationService.AttachLogo(logo);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(formFile);
        }
    }
}