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
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        private readonly IMarcaApplicationService _marcaApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService, IMarcaApplicationService marcaApplicationService, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                    base(domainNotificationHandler)
        {
            _produtoApplicationService = produtoApplicationService;
            _marcaApplicationService = marcaApplicationService;
        }

        public IActionResult Index(Guid? marcaId, string minValor, string maxValor, int? minQuantidade, int? maxQuantidade, string nome, int pageNumber = 1, int pageSize = 20)
        {
            var valorSpecification = new ProdutoPrecoVendaSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
            var quantidadeSpecification = new ProdutoQuantidadeSpecification(minQuantidade, maxQuantidade);
            var nomeSpecification = new ProdutoNomeSpecification(nome);

            var list = _produtoApplicationService.Get(valorSpecification
                .And(quantidadeSpecification)
                .And(nomeSpecification)
                .ToExpression());

            var viewModel = new ProdutosIndexViewModel
            {
                Produtos = list.ToPagedList(pageNumber, pageSize),
                Marcas = _marcaApplicationService.Get(),
                MarcaId = marcaId,
                Nome = nome,
                MinValor = minValor,
                MaxValor = maxValor,
                MinQuantidade = minQuantidade,
                MaxQuantidade = maxQuantidade,
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

        public JsonResult GetMarcas()
        {
            return Json(_marcaApplicationService.Get());
        }
    }
}