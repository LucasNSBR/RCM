using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels.ProdutoViewModels;
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
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService, IMarcaApplicationService marcaApplicationService, IAplicacaoApplicationService aplicacaoApplicationService, IFornecedorApplicationService fornecedorApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                    base(domainNotificationHandler)
        {
            _produtoApplicationService = produtoApplicationService;
            _marcaApplicationService = marcaApplicationService;
            _aplicacaoApplicationService = aplicacaoApplicationService;
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        public IActionResult Index(string produtoId, string nome, string aplicacaoMarca, string aplicacaoModelo, string aplicacaoMotor, string aplicacaoObservacao, string referenciaFabricante, string referenciaOriginal, string referenciaAuxiliar, Guid? marcaId, string minValor, string maxValor, int? minEstoque, int? maxEstoque, int pageNumber = 1, int pageSize = 20)
        {
            var idSpecification = new ProdutoIdSpecification(produtoId);
            var nomeSpecification = new ProdutoNomeSpecification(nome);
            var referenciaFabricanteSpecification = new ProdutoReferenciaFabricanteSpecification(referenciaFabricante);
            var referenciaOriginalSpecification = new ProdutoReferenciaOriginalSpecification(referenciaOriginal);
            var referenciaAuxiliarSpecification = new ProdutoReferenciaAuxiliarSpecification(referenciaAuxiliar);
            var marcaIdSpecification = new ProdutoMarcaIdSpecification(marcaId);
            var valorSpecification = new ProdutoPrecoVendaSpecification(minValor.ToDecimal(), maxValor.ToDecimal());
            var estoqueSpecification = new ProdutoEstoqueSpecification(minEstoque, maxEstoque);
            var aplicacaoMarcaSpecification = new ProdutoAplicacaoMarcaSpecification(aplicacaoMarca);
            var aplicacaoModeloSpecification = new ProdutoAplicacaoModeloSpecification(aplicacaoModelo);
            var aplicacaoMotorSpecification = new ProdutoAplicacaoMotorSpecification(aplicacaoMotor);
            var aplicacaoObservacaoSpecification = new ProdutoAplicacaoObservacaoSpecification(aplicacaoObservacao);

            var list = _produtoApplicationService.Get(idSpecification
                .And(nomeSpecification)
                .And(aplicacaoMarcaSpecification)
                .And(aplicacaoModeloSpecification)
                .And(aplicacaoMotorSpecification)
                .And(aplicacaoObservacaoSpecification)
                .And(referenciaFabricanteSpecification)
                .And(referenciaOriginalSpecification)
                .And(referenciaAuxiliarSpecification)
                .And(valorSpecification)
                .And(estoqueSpecification)
                .And(marcaIdSpecification)
                .ToExpression());

            var viewModel = new ProdutosIndexViewModel
            {
                Produtos = list.ToPagedList(pageNumber, pageSize),
                Marcas = _marcaApplicationService.Get().OrderBy(m => m.Nome),
                MarcaId = marcaId,
                ProdutoId = produtoId,
                Nome = nome,
                ReferenciaFabricante = referenciaFabricante,
                ReferenciaOriginal = referenciaOriginal,
                ReferenciaAuxiliar = referenciaAuxiliar,
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

            if (produto.Aplicacoes != null)
            {
                produto.Aplicacoes = produto.Aplicacoes.OrderBy(a => a.CarroMarca)
                    .ThenBy(a => a.CarroModelo)
                    .ThenBy(a => a.CarroMotor)
                    .ToList();
            }

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
                return RedirectToAction(nameof(Details), new { id = produto.Id });
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

        [Authorize(Policy = "ActiveUser")]
        public IActionResult AttachSupplier(Guid id)
        {
            ProdutoFornecedorViewModel produtoFornecedor = new ProdutoFornecedorViewModel()
            {
                ProdutoId = id,
            };

            return View(produtoFornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        public async Task<IActionResult> AttachSupplier(ProdutoFornecedorViewModel produtoFornecedor)
        {
            var commandResult = await _produtoApplicationService.AdicionarFornecedor(produtoFornecedor);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id = produtoFornecedor.ProdutoId });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(produtoFornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> UnattachSupplier(Guid id, Guid fornecedorId)
        {
            var commandResult = await _produtoApplicationService.RemoverFornecedor(id, fornecedorId);

            if (commandResult.Success)
                NotifyCommandResultSuccess();
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return RedirectToAction(nameof(Details), new { id });
        }

        public JsonResult GetFornecedores()
        {
            return Json(_fornecedorApplicationService.Get()
                .OrderBy(f => f.Nome));
        }

        public JsonResult GetAplicacoes()
        {
            return Json(_aplicacaoApplicationService.Get());
        }

        public JsonResult GetMarcas()
        {
            return Json(_marcaApplicationService.Get()
                .OrderBy(m => m.Nome));
        }
    }
}