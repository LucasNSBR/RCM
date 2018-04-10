using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.Extensions;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.DuplicataModels;
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

        public IActionResult Index(bool? apenasNaoPagas, bool? apenasVencidas, decimal? minValor, decimal? maxValor, Guid? fornecedorId, string numeroDocumento = null, string dataEmissao = null, string dataVencimento = null, int pageNumber = 1, int pageSize = 20)
        {
            var pagaSpecification = new DuplicataNaoPagaSpecification(apenasNaoPagas);
            var vencidaSpecification = new DuplicataVencidaSpecification(apenasVencidas);
            var valorSpecification = new DuplicataValorSpecification(minValor, maxValor);
            var fornecedorIdSpecification = new DuplicataFornecedorIdSpecification(fornecedorId);
            var numeroDocumentoSpecification = new DuplicataNumeroDocumentoSpecification(numeroDocumento);
            var dataSpecification = new DuplicataDataSpecification(dataEmissao.ToDateTime(), dataVencimento.ToDateTime());

            var list = _duplicataApplicationService.Get(pagaSpecification
                .And(vencidaSpecification)
                .And(valorSpecification)
                .And(fornecedorIdSpecification)
                .And(numeroDocumentoSpecification)
                .And(dataSpecification)
                .ToExpression())
                .OrderBy(d => d.DataVencimento)
                .ThenBy(d => d.FornecedorId)
                .ThenBy(d => d.NumeroDocumento);

            var viewModel = new DuplicataIndexViewModel {
                Duplicatas = list.ToPagedList(pageNumber, pageSize),
                Fornecedores = _fornecedorApplicationService.Get(),
                ApenasNaoPagas = apenasNaoPagas,
                ApenasVencidas = apenasVencidas,
                MinValor = minValor,
                MaxValor = maxValor,
                FornecedorId = fornecedorId,
                NumeroDocumento = numeroDocumento,
                DataEmissao = dataEmissao,
                DataVencimento = dataVencimento
            };

            return View(viewModel);
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
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DuplicataViewModel duplicata)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(duplicata);
            }
            
            var commandResult = await _duplicataApplicationService.Add(duplicata);

            if (commandResult.Success)
                return RedirectToAction(nameof(Index));

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null)
                return NotFound();

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DuplicataViewModel duplicata)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(duplicata);
            }

            var commandResult = await _duplicataApplicationService.Update(duplicata);

            if(commandResult.Success)
                return RedirectToAction(nameof(Index));

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
        public async Task<IActionResult> Delete(Guid id, DuplicataViewModel duplicata)
        {
            var commandResult = await _duplicataApplicationService.Remove(duplicata);

            if (commandResult.Success)
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
        public async Task<IActionResult> Payment(Guid id, PagamentoViewModel pagamento)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || !duplicata.Pagamento.IsEmpty)
                return NotFound();

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(pagamento);
            }
            
            var commandResult = await _duplicataApplicationService.Pagar(duplicata, pagamento);

            if (commandResult.Success)
                return RedirectToAction(nameof(Details), new { id });

            return View(pagamento);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> CancelPayment(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || duplicata.Pagamento.IsEmpty)
                return NotFound();

            var commandResult = await _duplicataApplicationService.Estornar(duplicata);

            if (commandResult.Success)
                return RedirectToAction(nameof(Details), new { duplicata.Id });

            return View();
        }

        public JsonResult GetFornecedores()
        {
            return Json(_fornecedorApplicationService.Get().ToList());
        }
    }
}
