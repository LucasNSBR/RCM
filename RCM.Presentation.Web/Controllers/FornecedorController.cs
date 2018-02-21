using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public FornecedorController(IFornecedorApplicationService fornecedorApplicationService)
        {
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        [HttpGet]
        public IEnumerable<FornecedorViewModel> Get()
        {
            return _fornecedorApplicationService.Get();
        }

        [HttpGet("{id}")]
        public FornecedorViewModel Get(int id)
        {
            return _fornecedorApplicationService.GetById(id);
        }
        
        [HttpPost]
        public void Post(FornecedorViewModel viewModel)
        {
            _fornecedorApplicationService.Add(viewModel);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, FornecedorViewModel viewModel)
        {
            _fornecedorApplicationService.Update(viewModel);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fornecedorApplicationService.Remove(new FornecedorViewModel { Id = id });
        }
    }
}
