using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.MarcaModels;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.Extensions;
using RCM.Presentation.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Area("Platform")]
    [Authorize]
    public class MarcasController : BaseController
    {
        private readonly IMarcaApplicationService _marcaApplicationService;

        public MarcasController(IMarcaApplicationService marcaApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _marcaApplicationService = marcaApplicationService;
        }

        public IActionResult Index(string nome = null, int pageNumber = 1, int pageSize = 20)
        {
            var nomeSpecification = new MarcaNomeSpecification(nome);

            var list = _marcaApplicationService.Get(nomeSpecification
                .ToExpression());

            var viewModel = new MarcaIndexViewModel
            {
                Marcas = list.ToPagedList(pageNumber, pageSize),
                Nome = nome
            };

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var marca = _marcaApplicationService.GetById(id);
            if (marca == null)
                return NotFound();

            return View(marca);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaViewModel marca)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(marca);
            }

            var commandResult = await _marcaApplicationService.Add(marca);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(marca);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var marca = _marcaApplicationService.GetById(id);
            if (marca == null)
                return NotFound();

            return View(marca);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MarcaViewModel marca)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(marca);
            }

            var commandResult = await _marcaApplicationService.Update(marca);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(marca);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var produto = _marcaApplicationService.GetById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, MarcaViewModel marca)
        {
            var commandResult = await _marcaApplicationService.Remove(marca);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(marca);
        }
    }
}