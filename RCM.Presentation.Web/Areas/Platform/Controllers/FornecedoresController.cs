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
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public FornecedoresController(IFornecedorApplicationService fornecedorApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                                base(domainNotificationHandler)
        {
            _fornecedorApplicationService = fornecedorApplicationService;
        }
        
        public IActionResult Index()
        {
            var list = _fornecedorApplicationService.Get();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorViewModel fornecedor)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(fornecedor);
            }

            _fornecedorApplicationService.Add(fornecedor);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(int id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FornecedorViewModel fornecedor)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(fornecedor);
            }

            _fornecedorApplicationService.Update(fornecedor);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(int id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, FornecedorViewModel fornecedor)
        {
            _fornecedorApplicationService.Remove(fornecedor);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(fornecedor);
        }
    }
}
