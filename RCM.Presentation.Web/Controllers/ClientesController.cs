using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            return _clienteApplicationService.Get();
        }

        [HttpGet("{id}")]
        public ClienteViewModel Get(int id)
        {
            return _clienteApplicationService.GetById(id);
        }

        [HttpPost]
        public void Post(ClienteViewModel viewModel)
        {
            _clienteApplicationService.Add(viewModel);
        }

        [HttpPut("{id}")]
        public void Put(int id, ClienteViewModel viewModel)
        {
            _clienteApplicationService.Update(viewModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteApplicationService.Remove(new ClienteViewModel { Id = id });
        }
    }
}
