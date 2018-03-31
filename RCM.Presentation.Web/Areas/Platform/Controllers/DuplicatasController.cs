using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System;
using System.Linq;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "Manager")]
    [Area("Platform")]
    public class DuplicatasController : BaseController
    {
        private readonly IDuplicataApplicationService _duplicataApplicationService;
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public DuplicatasController(IDuplicataApplicationService duplicataApplicationService, IFornecedorApplicationService fornecedorApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                            base(domainNotificationHandler)
        {
            _duplicataApplicationService = duplicataApplicationService;
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        public IActionResult Index()
        {
            var list = _duplicataApplicationService.Get();
            return View(list);
        }
        
        public IActionResult Details(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            var duplicata = PopulateSelectLists(new DuplicataViewModel());
            return View(duplicata);
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

            duplicata = PopulateSelectLists(duplicata);
            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            duplicata = PopulateSelectLists(duplicata);
            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, DuplicataViewModel duplicata)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(duplicata);
            }

            _duplicataApplicationService.Update(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));

            duplicata = PopulateSelectLists(duplicata);
            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, DuplicataViewModel duplicata)
        {
            _duplicataApplicationService.Remove(duplicata);

            if (Success())
                return RedirectToAction(nameof(Index));

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Payment(Guid id)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(Guid id, PagamentoViewModel pagamento)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || !duplicata.Pagamento.IsEmpty)
                return NotFound();

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(pagamento);
            }
            
            _duplicataApplicationService.Pagar(duplicata, pagamento);

            if (Success())
                return RedirectToAction(nameof(Details), new { id });

            return View(pagamento);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult CancelPayment(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || duplicata.Pagamento.IsEmpty)
                return NotFound();

            _duplicataApplicationService.Estornar(duplicata);

            if (Success())
                return RedirectToAction(nameof(Details), new { duplicata.Id });

            return View();
        }

        public DuplicataViewModel PopulateSelectLists(DuplicataViewModel viewModel)
        {
            viewModel.Fornecedores = _fornecedorApplicationService.Get().ToList();
            return viewModel;
        }
    }
}
