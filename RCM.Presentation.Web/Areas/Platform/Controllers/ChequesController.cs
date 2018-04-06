using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.Extensions;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ChequeModels;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "Manager")]
    [Area("Platform")]
    public class ChequesController : BaseController
    {
        private readonly IChequeApplicationService _chequeApplicationService;
        private readonly IBancoApplicationService _bancoApplicationService;
        private readonly IClienteApplicationService _clienteApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService, IClienteApplicationService clienteApplicationService, IBancoApplicationService bancoApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                    base(domainNotificationHandler)
        {
            _chequeApplicationService = chequeApplicationService;
            _bancoApplicationService = bancoApplicationService;
            _clienteApplicationService = clienteApplicationService;
        }

        public IActionResult Index(decimal? minValor, decimal? maxValor, Guid? clienteId, string agencia = null, string conta = null, string numeroCheque = null, string dataEmissao = null, string dataVencimento = null)
        {
            var valorSpecification = new ChequeValorSpecification(minValor, maxValor);
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var agenciaSpecification = new ChequeAgenciaSpecification(agencia);
            var contaSpecification = new ChequeContaCorrenteSpecification(conta);
            var numeroSpecification = new ChequeNumeroSpecification(numeroCheque);
            var dataSpecification = new ChequeDataSpecification(dataEmissao.ToDateTime(), dataVencimento.ToDateTime());

            var list = _chequeApplicationService.Get(valorSpecification
                .And(clienteIdSpecification)
                .And(agenciaSpecification)
                .And(contaSpecification)
                .And(numeroSpecification)
                .And(dataSpecification)
                .ToExpression());

            var viewModel = new ChequesIndexViewModel { Cheques = list, Clientes = _clienteApplicationService.Get() };
            return View(viewModel);
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
            var cheque = PopulateSelectLists(new ChequeViewModel());
            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChequeViewModel cheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cheque);
            }

            var commandResult = await _chequeApplicationService.Add(cheque);

            if (commandResult.Success) 
                return RedirectToAction(nameof(Index));

            cheque = PopulateSelectLists(cheque);
            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var cheque = _chequeApplicationService.GetById(id);
            if (cheque == null)
                return NotFound();

            cheque = PopulateSelectLists(cheque);
            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ChequeViewModel cheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cheque);
            }

            var commandResult = await _chequeApplicationService.Update(cheque);

            if (commandResult.Success)
                return RedirectToAction(nameof(Index));

            cheque = PopulateSelectLists(cheque);
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
        public async Task<IActionResult> Delete(Guid id, ChequeViewModel cheque)
        {
            var commandResult = await _chequeApplicationService.Remove(cheque);

            if (commandResult.Success)
                return RedirectToAction(nameof(Index));
            else
                return View(cheque);
        }

        private ChequeViewModel PopulateSelectLists(ChequeViewModel chequeViewModel)
        {
            chequeViewModel.Clientes = _clienteApplicationService.Get().ToList();
            chequeViewModel.Bancos = _bancoApplicationService.Get().ToList();
            return chequeViewModel;
        }
    }
}
