using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_clienteApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _clienteApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return Response(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _clienteApplicationService.Add(viewModel);
            return Response(viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ClienteViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return Response();
            }

            _clienteApplicationService.Update(viewModel);
            return Response(viewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteApplicationService.Remove(new ClienteViewModel { Id = id });
            return Response();
        }
    }
}
