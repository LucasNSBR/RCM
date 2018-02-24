using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/NotasFiscais")]
    public class NotasFiscaisController : ApiController
    {
        private readonly INotaFiscalApplicationService _notaFiscalApplicationService;

        public NotasFiscaisController(INotaFiscalApplicationService notaFiscalApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _notaFiscalApplicationService = notaFiscalApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_notaFiscalApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _notaFiscalApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return Response(model);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]NotaFiscalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _notaFiscalApplicationService.Add(viewModel);
            return Response(viewModel);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]NotaFiscalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _notaFiscalApplicationService.Update(viewModel);
            return Response(viewModel);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _notaFiscalApplicationService.Remove(new NotaFiscalViewModel { Id = id });
            return Response();
        }
    }
}
