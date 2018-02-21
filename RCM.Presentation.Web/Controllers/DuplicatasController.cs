using System.Collections.Generic;
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
        public DuplicataViewModel Get(int id)
        {
            return _duplicataApplicationService.GetById(id);
        }
        
        [HttpPost]
        public void Post(DuplicataViewModel viewModel)
        {
            _duplicataApplicationService.Add(viewModel);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, DuplicataViewModel viewModel)
        {
            _duplicataApplicationService.Update(viewModel);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _duplicataApplicationService.Remove(new DuplicataViewModel { Id = id });
        }
    }
}
