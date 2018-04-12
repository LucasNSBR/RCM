using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.Extensions;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ChequeModels;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.Extensions;
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

        public IActionResult Index(Guid? clienteId, string minValor, string maxValor, string agencia = null, string conta = null, string numeroCheque = null, string dataEmissao = null, string dataVencimento = null, int pageNumber = 1, int pageSize = 20)
        {
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var valorSpecification = new ChequeValorSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
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

            var viewModel = new ChequesIndexViewModel
            {
                Cheques = list.ToPagedList(pageNumber, pageSize),
                Clientes = _clienteApplicationService.Get(),
                MinValor = minValor,
                MaxValor = maxValor,
                ClienteId = clienteId,
                Agencia = agencia,
                Conta = conta,
                NumeroCheque = numeroCheque,
                DataEmissao = dataEmissao,
                DataVencimento = dataVencimento,
            };

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
            return View();
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
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

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
        public async Task<IActionResult> Edit(Guid id, ChequeViewModel cheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cheque);
            }

            var commandResult = await _chequeApplicationService.Update(cheque);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

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
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);
            
            return View(cheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> BloquearCheque(Guid id)
        {
            var commandResult = await _chequeApplicationService.BloquearCheque(id);

            if (!commandResult.Success)
            {

            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> CompensarCheque(Guid id)
        {
            var commandResult = await _chequeApplicationService.CompensarCheque(id);

            if (!commandResult.Success)
            {

            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> RepassarCheque(Guid id)
        {
            var commandResult = await _chequeApplicationService.RepassarCheque(id);

            if (!commandResult.Success)
            {

            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> DevolverCheque(Guid id)
        {
            var commandResult = await _chequeApplicationService.DevolverCheque(id);

            if (!commandResult.Success)
            {

            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> SustarCheque(Guid id)
        {
            var commandResult = await _chequeApplicationService.SustarCheque(id);

            if (!commandResult.Success)
            {

            }

            return RedirectToAction(nameof(Details), new { id });
        }


        public JsonResult GetClientes()
        {
            return Json(_clienteApplicationService.Get().ToList());
        }

        public JsonResult GetBancos()
        {
            return Json(_bancoApplicationService.Get().ToList());
        }
    }
}
