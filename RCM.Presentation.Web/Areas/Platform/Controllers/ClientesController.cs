using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.ClienteModels;
using RCM.Presentation.Web.Controllers;
using System;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class ClientesController : BaseController
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                      base(domainNotificationHandler)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        public IActionResult Index(string nome = null)
        {
            var nomeSpecification = new ClienteNomeSpecification(nome);

            var list = _clienteApplicationService.Get(nomeSpecification
                .ToExpression());

            return View(list);
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
                return RedirectToAction(nameof(Index));
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

        [Authorize(Policy = "ActiveUser")]
        public IActionResult AttachContato(Guid id)
        {
            var contato = new ContatoViewModel()
            {
                Id = id
            };

            return View(contato);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttachContato(ContatoViewModel contato)
        {
            var commandResult = await _clienteApplicationService.AdicionarContato(contato);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Details), new { id = contato.Id });
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(contato);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> RemoveContato(Guid id)
        {
            var commandResult = await _clienteApplicationService.RemoverContato(id);

            if (commandResult.Success)
                NotifyCommandResultSuccess();
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
