using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    public abstract class ApiController : Controller
    {
        protected readonly IDomainNotificationHandler _domainNotificationHandler;

        public ApiController(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected new IActionResult Response(object result)
        {
            return Ok(new { data = result });
        }
    }
}