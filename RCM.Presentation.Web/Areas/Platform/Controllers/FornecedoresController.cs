using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.FornecedorModels;
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
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorApplicationService _fornecedorApplicationService;
        private readonly ICidadeApplicationService _cidadeApplicationService;

        public FornecedoresController(IFornecedorApplicationService fornecedorApplicationService, ICidadeApplicationService cidadeApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                                base(domainNotificationHandler)
        {
            _fornecedorApplicationService = fornecedorApplicationService;
            _cidadeApplicationService = cidadeApplicationService;
        }

        public IActionResult Index(string nome = null, int? tipo = null, string cadastroNacional = null, string cadastroEstadual = null, int pageNumber = 1, int pageSize = 20)
        {
            var nomeSpecification = new FornecedorNomeSpecification(nome);
            var tipoSpecification = new FornecedorTipoSpecification(tipo);
            var cadastroNacionalSpecification = new FornecedorCadastroNacionalSpecification(cadastroNacional);
            var cadastroEstadualSpecification = new FornecedorCadastroEstadualSpecification(cadastroEstadual);

            var list = _fornecedorApplicationService.Get(nomeSpecification
                .And(tipoSpecification)
                .And(cadastroNacionalSpecification)
                .And(cadastroEstadualSpecification)
                .ToExpression());

            var viewModel = new FornecedorIndexViewModel
            {
                Fornecedores = list.ToPagedList(pageNumber, pageSize),
                Nome = nome,
                Tipo = tipo,
                CadastroNacional = cadastroNacional,
                CadastroEstadual = cadastroEstadual,
            };

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedor)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(fornecedor);
            }

            var commandResult = await _fornecedorApplicationService.Add(fornecedor);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedor)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(fornecedor);
            }

            var commandResult = await _fornecedorApplicationService.Update(fornecedor);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var fornecedor = _fornecedorApplicationService.GetById(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, FornecedorViewModel fornecedor)
        {
            var commandResult = await _fornecedorApplicationService.Remove(fornecedor);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(fornecedor);
        }

        public JsonResult GetCidades()
        {
            return Json(_cidadeApplicationService.Get()
                .OrderBy(e => e.Nome));
        }
    }
}
