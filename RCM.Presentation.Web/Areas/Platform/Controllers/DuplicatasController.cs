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
    public class DuplicatasController : BaseController
    {
        private readonly IDuplicataApplicationService _duplicataApplicationService;

        public DuplicatasController(IDuplicataApplicationService duplicataApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                            base(domainNotificationHandler)
        {
            _duplicataApplicationService = duplicataApplicationService;
        }

        public IActionResult Index()
        {
            var list = _duplicataApplicationService.Get();
            return View(list);
        }
        
        public IActionResult Details(int id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DuplicataViewModel duplicata)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(duplicata);
            }

            _duplicataApplicationService.Add(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));
            
            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(int id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DuplicataViewModel duplicata)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(duplicata);
            }

            _duplicataApplicationService.Update(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));
            
            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(int id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, DuplicataViewModel duplicata)
        {
            _duplicataApplicationService.Remove(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pagamento(DuplicataViewModel duplicata, DateTime dataPagamento, decimal valorPago)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return RedirectToAction(nameof(Details), duplicata);
            }
            
            _duplicataApplicationService.Pagar(duplicata, dataPagamento, valorPago);

            if (Success())
                return RedirectToAction(nameof(Details), duplicata);

            return RedirectToAction(nameof(Details));
        }
    }
}
