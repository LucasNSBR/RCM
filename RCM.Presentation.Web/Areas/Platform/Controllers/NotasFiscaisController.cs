using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class NotasFiscaisController : BaseController
    {
        private readonly INotaFiscalApplicationService _notaFiscalApplicationService;

        public NotasFiscaisController(INotaFiscalApplicationService notaFiscalApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                                base(domainNotificationHandler)
        {
            _notaFiscalApplicationService = notaFiscalApplicationService;
        }

        public IActionResult Index()
        {
            var list = _notaFiscalApplicationService.Get();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var notaFiscal = _notaFiscalApplicationService.GetById(id);
            if (notaFiscal == null)
                return NotFound();

            return View(notaFiscal);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotaFiscalViewModel notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(notaFiscal);
            }

            _notaFiscalApplicationService.Add(notaFiscal);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(notaFiscal);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(int id)
        {
            var notaFiscal = _notaFiscalApplicationService.GetById(id);
            if (notaFiscal == null)
                return NotFound();

            return View(notaFiscal);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NotaFiscalViewModel notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(notaFiscal);
            }

            _notaFiscalApplicationService.Update(notaFiscal);

            if (Success())
                return RedirectToAction(nameof(notaFiscal));
            else
                return View(notaFiscal);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(int id)
        {
            var notaFiscal = _notaFiscalApplicationService.GetById(id);
            if (notaFiscal == null)
                return NotFound();

            return View(notaFiscal);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, NotaFiscalViewModel notaFiscal)
        {
            _notaFiscalApplicationService.Remove(notaFiscal);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(notaFiscal);
        }
    }
}
