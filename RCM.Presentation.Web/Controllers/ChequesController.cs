using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Cheques")]
    public class ChequesController : ApiController
    {
        private readonly IChequeApplicationService _chequeApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_chequeApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _chequeApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return Response(model);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]ChequeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            return Response(model);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ChequeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _chequeApplicationService.Update(model);
            return Response(model);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _chequeApplicationService.Remove(new ChequeViewModel { Id = id });
            return Response();
        }
    }
}
