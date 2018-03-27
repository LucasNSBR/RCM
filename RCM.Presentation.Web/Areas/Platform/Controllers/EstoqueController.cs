using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ProdutoModels;
using RCM.Presentation.Web.Controllers;

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

        public IActionResult Index(string nome = null, string aplicacao = null)
        {
            var nomeSpecification = new ProdutoNomeSpecification(nome);
            var aplicacaoSpecification = new ProdutoAplicacaoSpecification(aplicacao);

            var list = _produtoApplicationService.Get(nomeSpecification
                .And(aplicacaoSpecification)
                .ToExpression());

            return View(list);
        }

        public IActionResult Details(int id)
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
        public IActionResult Create(ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(produto);
            }

            _produtoApplicationService.Add(produto);

            if (Success())
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(int id)
        {
            var produto = _produtoApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }


        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(produto);
            }

            _produtoApplicationService.Update(produto);

            if (Success())
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, ProdutoViewModel produto)
        {
            _produtoApplicationService.Remove(produto);

            if (Success())
                return RedirectToAction(nameof(Index));

            return View(produto);
        }
    }
}