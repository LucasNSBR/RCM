using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ClienteModels;
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
    public class ClientesController : BaseController
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        private readonly ICidadeApplicationService _cidadeApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService, ICidadeApplicationService cidadeApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                      base(domainNotificationHandler)
        {
            _clienteApplicationService = clienteApplicationService;
            _cidadeApplicationService = cidadeApplicationService;
        }

        public IActionResult Index(string nome, string tipo, string pontuacao, string cadastroNacional, string cadastroEstadual, int pageNumber = 1, int pageSize = 20)
        {
            var nomeSpecification = new ClienteNomeSpecification(nome);
            var tipoSpecification = new ClienteTipoSpecification(tipo);
            var pontuacaoSpecification = new ClientePontuacaoSpecification(pontuacao);
            var cadastroNacionalSpecification = new ClienteCadastroNacionalSpecification(cadastroNacional);
            var cadastroEstadualSpecification = new ClienteCadastroEstadualSpecification(cadastroEstadual);

            var list = _clienteApplicationService.Get(nomeSpecification
                .And(tipoSpecification)
                .And(pontuacaoSpecification)
                .And(cadastroNacionalSpecification)
                .And(cadastroEstadualSpecification)
                .ToExpression());

            var viewModel = new ClienteIndexViewModel
            {
                Clientes = list.ToPagedList(pageNumber, pageSize),
                Nome = nome,
                Tipo = tipo,
                Pontuacao = pontuacao,
                CadastroNacional = cadastroNacional,
                CadastroEstadual = cadastroEstadual,
            };

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var cliente = _clienteApplicationService.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cliente);
            }

            var commandResult = await _clienteApplicationService.Add(cliente);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var cliente = _clienteApplicationService.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cliente);
            }

            var commandResult = await _clienteApplicationService.Update(cliente);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id = cliente.Id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var cliente = _clienteApplicationService.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ClienteViewModel cliente)
        {
            var commandResult = await _clienteApplicationService.Remove(cliente);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(cliente);
        }

        public JsonResult GetCidades()
        {
            return Json(_cidadeApplicationService.Get()
                .OrderBy(e => e.Nome));
        }
    }
}
