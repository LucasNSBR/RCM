using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using System;

namespace RCM.Presentation.Web.Controllers
{
    public class DuplicatasController : BaseController
    {
        private readonly IDuplicataApplicationService _duplicataApplicationService;

        public DuplicatasController(IDuplicataApplicationService duplicataApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
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
            var model = _duplicataApplicationService.GetById(id);
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
            else
                return View(duplicata);
        }
        
        public IActionResult Edit(int id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

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
            else
                return View(duplicata);
        }
        
        public IActionResult Delete(int id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, DuplicataViewModel duplicata)
        {
            _duplicataApplicationService.Remove(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(duplicata);
        }
    }
}
