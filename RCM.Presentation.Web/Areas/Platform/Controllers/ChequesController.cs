using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "Manager")]
    [Area("Platform")]
    public class ChequesController : BaseController
    {
        private readonly IChequeApplicationService _chequeApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                    base(domainNotificationHandler)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        public IActionResult Index()
        {
            var list = _chequeApplicationService.Get();
            return View(list);
        }
        
        public IActionResult Details(Guid id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChequeViewModel cheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cheque);
            }

            _chequeApplicationService.Add(cheque);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ChequeViewModel cheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cheque);
            }

            _chequeApplicationService.Update(cheque);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, ChequeViewModel cheque)
        {
            _chequeApplicationService.Remove(cheque);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cheque);
        }
    }
}
