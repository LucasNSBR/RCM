using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System.Linq;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class ChequesController : BaseController
    {
        private readonly IChequeApplicationService _chequeApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        public IActionResult Index(string clienteName = "")
        {
            var list = _chequeApplicationService.Get()
                .Where(c => c.Cliente.Nome.ToLower().Contains(clienteName.ToLower()))
                .OrderBy(c => c.Cliente.Nome);

            return View(list);
        }
        
        public IActionResult Details(int id)
        {
            var model = _chequeApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        
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
        
        public IActionResult Edit(int id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            return View(cheque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ChequeViewModel cheque)
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

        public IActionResult Delete(int id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            return View(cheque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, ChequeViewModel cheque)
        {
            _chequeApplicationService.Remove(cheque);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cheque);
        }
    }
}
