using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ProdutoModels;
using RCM.Presentation.Web.Controllers;
using System;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class EstoqueController : BaseController
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public EstoqueController(IProdutoApplicationService produtoApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                    base(domainNotificationHandler)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        public IActionResult Index(decimal? minValor, decimal? maxValor, int? minQuantidade, int? maxQuantidade, string nome = null, string aplicacao = null)
        {
            var valorSpecification = new ProdutoPrecoVendaSpecification(minValor, maxValor);
            var quantidadeSpecification = new ProdutoQuantidadeSpecification(minQuantidade, maxQuantidade);
            var nomeSpecification = new ProdutoNomeSpecification(nome);
            var aplicacaoSpecification = new ProdutoAplicacaoSpecification(aplicacao);

            var list = _produtoApplicationService.Get(valorSpecification
                .And(quantidadeSpecification)
                .And(nomeSpecification)
                .And(aplicacaoSpecification)
                .ToExpression());

            return View(list);
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
                return RedirectToAction(nameof(Index));

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
                return RedirectToAction(nameof(Index));

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
                return RedirectToAction(nameof(Index));

            return View(produto);
        }
    }
}