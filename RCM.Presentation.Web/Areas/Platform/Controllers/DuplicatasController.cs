using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Application.ViewModels.ValueObjectViewModels;
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

        public IActionResult Index(bool? apenasNaoPagas, bool? apenasVencidas, Guid? fornecedorId, string numeroDocumento, string minValor, string maxValor, string dataInicial, string dataFinal, int pageNumber = 1, int pageSize = 20)
        {
            var pagaSpecification = new DuplicataNaoPagaSpecification(apenasNaoPagas);
            var vencidaSpecification = new DuplicataVencidaSpecification(apenasVencidas);
            var fornecedorIdSpecification = new DuplicataFornecedorIdSpecification(fornecedorId);
            var numeroDocumentoSpecification = new DuplicataNumeroDocumentoSpecification(numeroDocumento);
            var valorSpecification = new DuplicataValorSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
            var dataSpecification = new DuplicataDataSpecification(dataInicial.ToDateTime(), dataFinal.ToDateTime());

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
                Fornecedores = _fornecedorApplicationService.Get().OrderBy(f => f.Nome),
                ApenasNaoPagas = apenasNaoPagas,
                ApenasVencidas = apenasVencidas,
                MinValor = minValor,
                MaxValor = maxValor,
                FornecedorId = fornecedorId,
                NumeroDocumento = numeroDocumento,
                DataInicial = dataInicial,
                DataFinal = dataFinal,
                TotalResultados = list.ToList().Count(),
                ValorTotalResultados = list.ToList().Sum(d => d.Valor),
                ValorTotalVencidas = list.ToList().Where(d => d.Vencido).Sum(d => d.Valor)
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
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

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

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

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
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(duplicata);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Payment(Guid id)
        {
            var pagamentoViewModel = new PagamentoViewModel()
            {
                DuplicataId = id
            };

            return View(pagamentoViewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Guid id, PagamentoViewModel pagamento)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || duplicata.Pagamento != null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(pagamento);
            }
            
            var commandResult = await _duplicataApplicationService.Pagar(duplicata, pagamento);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);
            
            return View(pagamento);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> CancelPayment(Guid id)
        {
            var duplicata = _duplicataApplicationService.GetById(id);
            if (duplicata == null || duplicata.Pagamento == null)
                return NotFound();

            var commandResult = await _duplicataApplicationService.Estornar(duplicata);

            if (!commandResult.Success)
                NotifyCommandResultErrors(commandResult.Errors);
            else
                NotifyCommandResultSuccess();

            return RedirectToAction(nameof(Details), new { duplicata.Id });
        }

        public JsonResult GetFornecedores()
        {
            return Json(_fornecedorApplicationService.Get()
                .OrderBy(f => f.Nome));
        }
    }
}
