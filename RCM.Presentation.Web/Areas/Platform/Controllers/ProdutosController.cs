using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.Extensions;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ProdutoModels;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.Extensions;
using RCM.Presentation.Web.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        private readonly IMarcaApplicationService _marcaApplicationService;
        private readonly IAplicacaoApplicationService _aplicacaoApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService, IMarcaApplicationService marcaApplicationService, IAplicacaoApplicationService aplicacaoApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                    base(domainNotificationHandler)
        {
            _produtoApplicationService = produtoApplicationService;
            _marcaApplicationService = marcaApplicationService;
            _aplicacaoApplicationService = aplicacaoApplicationService;
        }

        public IActionResult Index(Guid? marcaId, string minValor, string maxValor, int? minEstoque, int? maxEstoque, string nome, int pageNumber = 1, int pageSize = 20)
        {
            var marcaIdSpecification = new ProdutoMarcaIdSpecification(marcaId);
            var valorSpecification = new ProdutoPrecoVendaSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
            var estoqueSpecification = new ProdutoEstoqueSpecification(minEstoque, maxEstoque);
            var nomeSpecification = new ProdutoNomeSpecification(nome);

            var list = _produtoApplicationService.Get(valorSpecification
                .And(estoqueSpecification)
                .And(nomeSpecification)
                .And(marcaIdSpecification)
                .ToExpression());

            var viewModel = new ProdutosIndexViewModel
            {
                Produtos = list.ToPagedList(pageNumber, pageSize),
                Marcas = _marcaApplicationService.Get().OrderBy(m => m.Nome),
                MarcaId = marcaId,
                Nome = nome,
                MinValor = minValor,
                MaxValor = maxValor,
                MinEstoque = minEstoque,
                MaxEstoque = maxEstoque,
            };

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var produto = _produtoApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(produto);
            }

            var commandResult = await _produtoApplicationService.Add(produto);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var produto = _produtoApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }


        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(produto);
            }

            var commandResult = await _produtoApplicationService.Update(produto);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var produto = _produtoApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ProdutoViewModel produto)
        {
            var commandResult = await _produtoApplicationService.Remove(produto);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult AttachApplication(Guid id)
        {
            AplicacaoViewModel aplicacao = new AplicacaoViewModel
            {
                ProdutoId = id
            };

            ModelState.Clear();
            return View(aplicacao);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttachApplication(AplicacaoViewModel viewModel)
        {
            var produto = _produtoApplicationService.GetById(viewModel.ProdutoId);
            if (produto == null)
                return NotFound();

            var aplicacao = _aplicacaoApplicationService.GetById(viewModel.Id);
            if (aplicacao == null)
                return NotFound();

            var commandResult = await _produtoApplicationService.RelacionarAplicacao(produto, viewModel);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id = viewModel.ProdutoId });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(viewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult CreateApplication(Guid id)
        {
            AplicacaoViewModel aplicacao = new AplicacaoViewModel
            {
                ProdutoId = id
            };

            ModelState.Clear();
            return View(aplicacao);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplication(AplicacaoViewModel aplicacao)
        {
            var produto = _produtoApplicationService.GetById(aplicacao.ProdutoId);
            if (produto == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(aplicacao);
            }

            var commandResult = await _produtoApplicationService.AdicionarAplicacao(produto, aplicacao);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id = aplicacao.ProdutoId });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(aplicacao);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> RemoveApplication(Guid id, Guid AplicacaoId)
        {
            var commandResult = await _produtoApplicationService.RemoverAplicacao(id, AplicacaoId);

            if (commandResult.Success)
                NotifyCommandResultSuccess();
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return RedirectToAction(nameof(Details), new { id });
        }

        public JsonResult GetAplicacoes()
        {
            return Json(_aplicacaoApplicationService.Get()
                .OrderBy(a => a.Marca)
                .ThenBy(a => a.Modelo)
                .ThenByDescending(a => a.Ano));
        }

        public JsonResult GetMarcas()
        {
            return Json(_marcaApplicationService.Get()
                .OrderBy(m => m.Nome));
        }
    }
}