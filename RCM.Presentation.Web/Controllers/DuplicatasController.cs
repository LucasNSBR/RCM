using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Duplicatas")]
    public class DuplicatasController : ApiController
    {
        private readonly IDuplicataApplicationService _duplicataApplicationService;

        public DuplicatasController(IDuplicataApplicationService duplicataApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _duplicataApplicationService = duplicataApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_duplicataApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_duplicataApplicationService.GetById(id));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]DuplicataViewModel viewModel)
        {
            _duplicataApplicationService.Add(viewModel);
            return Response(viewModel);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DuplicataViewModel viewModel)
        {
            _duplicataApplicationService.Update(viewModel);
            return Response(viewModel);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _duplicataApplicationService.Remove(new DuplicataViewModel { Id = id });
            return Response();
        }
    }
}
