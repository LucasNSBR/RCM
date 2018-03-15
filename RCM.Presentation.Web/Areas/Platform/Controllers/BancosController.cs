using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System.Linq;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class BancosController : BaseController
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public IActionResult Index(string bancoName = "")
        {
            var list = _bancoApplicationService.Get()
                .Where(b => b.Nome.ToLower().Contains(bancoName?.ToLower() ?? string.Empty));

            return View(list);
        }

        public IActionResult Details(int id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(banco);
            }

            _bancoApplicationService.Add(banco);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(banco);
        }

        public IActionResult Edit(int id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(banco);
            }

            _bancoApplicationService.Update(banco);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(banco);
        }

        public IActionResult Delete(int id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, BancoViewModel banco)
        {
            _bancoApplicationService.Remove(banco);

            if (Success())
                return RedirectToAction(nameof(Index));
            else
                return View(banco);
        }
    }
}
