﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.BancoModels;
using RCM.Presentation.Web.Controllers;
using RCM.Presentation.Web.Extensions;
using RCM.Presentation.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "Manager")]
    [Area("Platform")]
    public class BancosController : BaseController
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                base(domainNotificationHandler)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public IActionResult Index(int? codigoCompensacao = null, string nome = null, int pageNumber = 1, int pageSize = 20)
        {
            var codigoCompensacaoSpecification = new BancoCodigoCompensacaoSpecification(codigoCompensacao);
            var nomeSpecification = new BancoNomeSpecification(nome);

            var list = _bancoApplicationService.Get(codigoCompensacaoSpecification
                .And(nomeSpecification)
                .ToExpression());

            var viewModel = new BancoIndexViewModel
            {
                Bancos = list.ToPagedList(pageNumber, pageSize),
                CodigoCompensacao = codigoCompensacao,
                Nome = nome, 
            };

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(banco);
            }

            var commandResult = await _bancoApplicationService.Add(banco);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(banco);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(banco);
            }

            var commandResult = await _bancoApplicationService.Update(banco);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(banco);
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            var banco = _bancoApplicationService.GetById(id);
            if (banco == null)
                return NotFound();

            return View(banco);
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, BancoViewModel banco)
        {
            var commandResult = await _bancoApplicationService.Remove(banco);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                return View(banco);
        }
    }
}
