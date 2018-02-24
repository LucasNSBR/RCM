using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Fornecedor")]
    public class FornecedorController : ApiController
    {
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public FornecedorController(IFornecedorApplicationService fornecedorApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_fornecedorApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _fornecedorApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return Response(model);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]FornecedorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _fornecedorApplicationService.Add(viewModel);
            return Response(viewModel);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FornecedorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _fornecedorApplicationService.Update(viewModel);
            return Response(viewModel);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _fornecedorApplicationService.Remove(new FornecedorViewModel { Id = id });
            return Response();
        }
    }
}
