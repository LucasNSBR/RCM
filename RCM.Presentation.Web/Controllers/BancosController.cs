using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Bancos")]
    public class BancosController : ApiController
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_bancoApplicationService.Get());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _bancoApplicationService.GetById(id);
            if (model == null)
                return NotFound();

            return Response(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _bancoApplicationService.Add(banco);
            return Response(banco);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BancoViewModel banco)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _bancoApplicationService.Update(banco);
            return Response();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bancoApplicationService.Remove(new BancoViewModel() { Id = id });
            return Response();
        }
    }
}
