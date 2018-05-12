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

        public IActionResult Index(Guid? clienteId, string minValor, string maxValor, string agencia = null, string conta = null, string numeroCheque = null, string dataEmissao = null, string dataVencimento = null, string situacao = null, int pageNumber = 1, int pageSize = 20)
        {
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var valorSpecification = new ChequeValorSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
            var agenciaSpecification = new ChequeAgenciaSpecification(agencia);
            var contaSpecification = new ChequeContaCorrenteSpecification(conta);
            var numeroSpecification = new ChequeNumeroSpecification(numeroCheque);
            var dataSpecification = new ChequeDataSpecification(dataEmissao.ToDateTime(), dataVencimento.ToDateTime());
            var situacaoSpecification = new ChequeEstadoSpecification(situacao);

            var list = _chequeApplicationService.Get(valorSpecification
                .And(clienteIdSpecification)
                .And(agenciaSpecification)
                .And(contaSpecification)
                .And(numeroSpecification)
                .And(dataSpecification)
                .And(situacaoSpecification)
                .ToExpression());

            var viewModel = new ChequeIndexViewModel
            {
                Cheques = list.ToPagedList(pageNumber, pageSize),
                Clientes = _clienteApplicationService.Get().OrderBy(c => c.Nome),
                MinValor = minValor,
                MaxValor = maxValor,
                ClienteId = clienteId,
                Agencia = agencia,
                Conta = conta,
                NumeroCheque = numeroCheque,
                DataEmissao = dataEmissao,
                DataVencimento = dataVencimento,
                Situacao = situacao,
                TotalResultados = list.ToList().Count(),
                ValorTotalResultados = list.ToList().Sum(d => d.Valor),
                ValorTotalVencidos = list.ToList().Where(d => d.ItemProblema).Sum(d => d.Valor)
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
        public async Task<IActionResult> Bloquear(Guid id)
        {
            var commandResult = await _chequeApplicationService.BloquearCheque(id);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Compensar(Guid id)
        {
            var estadoChequeViewModel = new EstadoChequeViewModel()
            {
                ChequeId = id
            };

            return View(estadoChequeViewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compensar(Guid id, EstadoChequeViewModel estadoCheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(estadoCheque);
            }

            var commandResult = await _chequeApplicationService.CompensarCheque(id, estadoCheque);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(estadoCheque);
        }

        public IActionResult Repassar(Guid id)
        {
            var estadoChequeViewModel = new EstadoChequeViewModel()
            {
                ChequeId = id
            };

            return View(estadoChequeViewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Repassar(Guid id, EstadoChequeViewModel estadoCheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(estadoCheque);
            }

            var commandResult = await _chequeApplicationService.RepassarCheque(id, estadoCheque);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(estadoCheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Devolver(Guid id)
        {
            var estadoChequeViewModel = new EstadoChequeViewModel()
            {
                ChequeId = id
            };

            return View(estadoChequeViewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolver(Guid id, EstadoChequeViewModel estadoCheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(estadoCheque);
            }

            var commandResult = await _chequeApplicationService.DevolverCheque(id, estadoCheque);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(estadoCheque);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Sustar(Guid id)
        {
            var estadoChequeViewModel = new EstadoChequeViewModel()
            {
                ChequeId = id
            };

            return View(estadoChequeViewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sustar(Guid id, EstadoChequeViewModel estadoCheque)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(estadoCheque);
            }

            var commandResult = await _chequeApplicationService.SustarCheque(id, estadoCheque);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(estadoCheque);
        }


        public JsonResult GetClientes()
        {
            return Json(_clienteApplicationService.Get()
                .OrderBy(c => c.Nome));
        }

        public JsonResult GetBancos()
        {
            return Json(_bancoApplicationService.Get()
                .OrderBy(b => b.Nome));
        }
    }
}
