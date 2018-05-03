using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "ActiveUser")]
    [Area("Platform")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaApplicationService _empresaApplicationService;

        public EmpresaController(IEmpresaApplicationService empresaApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _empresaApplicationService = empresaApplicationService;
        }

        public IActionResult Attach()
        {
            return View();
        }

        public IActionResult Details()
        {
            var empresa = _empresaApplicationService.Get();
            if (empresa == null)
                return RedirectToAction(nameof(Attach));

            return View(empresa);
        }

        public IActionResult Update()
        {
            var empresa = _empresaApplicationService.Get();
            if (empresa == null)
                return View();

            return View(empresa);
        }

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
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(empresa);
        }
    }
}