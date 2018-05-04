using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class VendasController : BaseController
    {
        private readonly IVendaApplicationService _vendaApplicationService;

        public VendasController(IVendaApplicationService vendaApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _vendaApplicationService = vendaApplicationService;
        }

        public IActionResult Index()
        {
            var list = _vendaApplicationService.Get();

            return View(list);
        }
    }
}