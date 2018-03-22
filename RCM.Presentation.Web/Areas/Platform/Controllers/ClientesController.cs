using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;

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

        public IActionResult Index()
        {
            var list = _clienteApplicationService.Get();
            return View(list);
        }

        public IActionResult Details(int id)
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
        public IActionResult Create(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cliente);
            }

            _clienteApplicationService.Add(cliente);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(int id)
        {
            var cliente = _clienteApplicationService.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cliente);
            }

            _clienteApplicationService.Update(cliente);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteApplicationService.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, ClienteViewModel cliente)
        {
            _clienteApplicationService.Remove(cliente);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(cliente);
        }
    }
}
